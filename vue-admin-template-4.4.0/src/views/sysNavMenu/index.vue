<template>
  <div class="custom-tree-container">

    <el-col :span="24">
      <el-col :span="6">

        <div class="block">
          <el-input v-model="filterText" />
          <el-tree
            ref="tree"
            :data="data"
            accordion
            draggable
            node-key="id"
            highlight-current
            default-expand-all
            :expand-on-click-node="false"
            :filter-node-method="filterNode"

            @node-contextmenu="HandleNodeContextmenu"
            @current-change="HandleCurrentChange"
            @node-click="HandleNodeClick"
            @node-drop="HandleNodeDrop"
          >
            <span slot-scope="{ node,curData }" class="custom-tree-node">
              <span>{{ node.label }}</span>
              <span>
                <el-button
                  type="text"
                  size="mini"
                  @click="HandleDialog('create',node,curData)"
                >
                  新增
                </el-button>
                <el-button
                  type="text"
                  size="mini"
                  @click="() => HandleDialog('edit', node,curData)"
                >
                  编辑
                </el-button>
                <el-button
                  type="text"
                  size="mini"
                  @click="() => removeData(node)"
                >
                  删除
                </el-button>
              </span>
            </span>
          </el-tree>
        </div>
      </el-col>
      <el-col :span="10">
        <div class="block" />
      </el-col>
    </el-col>
    <el-dialog :title="dialogConfig.title" :visible.sync="dialogConfig.show" center="">
      <el-form v-model="form" :inline="false" label-width="80px">
        <el-form-item label="父级ID">
          <el-input v-model="form.parentId" />
        </el-form-item>
        <el-form-item label="父级菜单">
          <el-input v-model="form.parentName" />
        </el-form-item>
        <el-form-item label="菜单名称">
          <el-input v-model="form.label" placeholder="请输入密码" />
          <!-- <el-input v-model="form.Name" placeholder="菜单名称" /> -->
        </el-form-item>
        <el-form-item label="请求方式">
          <el-radio-group v-model="form.method">
            <el-radio v-for="item in enumTypes.methodTypes" :key="item.key" :label="item.key" />
          </el-radio-group>
        </el-form-item>

        <el-form-item label="连接地址">
          <el-input v-model="form.urlLink" placeholder="连接地址" />
        </el-form-item>

        <el-form-item label="叶子节点">
          <el-radio-group v-model="form.isLeaf">
            <el-radio-button v-for="item in enumTypes.isLeafTypes" :key="item.key" :label="item.key">是</el-radio-button>
          </el-radio-group>
        </el-form-item>
        <el-form-item label="按钮操作">
          <el-radio-group v-model="form.isButton">
            <el-radio v-for="item in enumTypes.isButtonTypes" :key="item.key" :label="item.key" border>是</el-radio>
          </el-radio-group>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">

        <el-button @click="dialogConfig.show = false">
          Cancel
        </el-button>
        <el-button type="primary" @click="dialogConfig.actionType==='create'?createData():updateData()">
          Confirm
        </el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>
import { getList, update, remove, insert } from '@/api/sysNavMenu'

export default {
  data() {
    return {
      data: null,
      form: {
        label: '',
        method: 'Put',
        urlLink: '',
        isLeaf: false,
        isButton: false,
        parentId: '',
        parentName: ''
      },
      enumTypes: {
        isLeafTypes: [
          { key: false, label: '否' },
          { key: true, label: '是' }
        ],
        isButtonTypes: [
          { key: false, label: '否' },
          { key: true, label: '是' }
        ],
        methodTypes: [
          { key: 'Get', label: 'Get' },
          { key: 'Post', label: 'Post' },
          { key: 'Put', label: 'Put' },
          { key: 'Delete', label: 'Delete' }
        ]
      },
      dialogConfig: {
        show: false,
        actionType: '',
        title: ''
      },
      filterText: ''
    }
  },
  watch: {
    filterText(val) {
      this.$refs.tree.filter(val)
    }
  },
  created: function() {
    this.LoadData()
  },
  methods: {
    LoadData: function() {
      getList().then(res => {
        this.data = res.data
        console.log(res.data)
      })
    },
    filterNode(value, data) {
      if (!value) return true
      return data.label.indexOf(value) !== -1
    },
    HandleNodeClick: function(data, b, c) {
      // this.form.parentName = data.label
      // this.form.parentId = data.id
      console.log('执行点击')
    },
    HandleNodeContextmenu: function() {

    },
    HandleCurrentChange: function() {
      console.log('选中改变')
    },
    HandleGetCurrentNode: function() {

    },
    HandleNodeDrop: function(node, toNode, location, event) {
      this.form = Object.assign({}, node.data)
      this.form.parentId = toNode.data.id

      this.updateData()
    },
    HandleDialog: function(type, node, curData) {
      console.log('curData', curData)
      if (type === 'create') {
        this.form = {
          label: '',
          method: 'Get',
          urlLink: '',
          isLeaf: false,
          isButton: false,
          parentId: '',
          parentName: ''
        }
        this.dialogConfig.actionType = 'create'
        this.dialogConfig.title = '菜单节点新增'
        this.form.parentName = node.data.label
        this.form.parentId = node.data.id
      } else {
        this.dialogConfig.actionType = 'edit'
        this.dialogConfig.title = '菜单节点编辑'
        this.form = Object.assign({}, node.data)
        this.form.parentName = node.parent.data.label
      }
      this.dialogConfig.show = true
    },
    resetForm: function() {
      this.form = {}
    },
    createData: function() {
      insert(this.form).then(res => {
        if (res.data != null) {
          this.$notify({
            title: '提示',
            message: '新增成功',
            duration: 2000,
            type: 'success'
          })
          this.dialogConfig.show = false
          this.LoadData()
        }
      })
    },
    updateData: function() {
      update(this.form).then(res => {
        this.dialogConfig.show = false
        this.$notify({
          title: '更新提示',
          message: '更改父节点完成',
          type: 'success',
          duration: 2000
        })
        this.LoadData()
      })
    },
    removeData: function(node) {
      console.log(node)
      if (node.childNodes.length > 0) {
        this.$notify({
          title: '删除提示',
          message: '请先删除子节点',
          type: 'error',
          duration: 2000
        })
      } else {
        remove({ id: node.data.id }).then(res => {
          this.$notify({
            title: '删除提示',
            message: '节点删除成功',
            type: 'success',
            duration: 2000
          })
          this.LoadData()
        })
      }
    }
  }
}
</script>

<style>
  .custom-tree-node {
    flex: 1;
    display: flex;
    align-items: center;
    justify-content: space-between;
    font-size: 14px;
    padding-right: 8px;
  }
</style>
