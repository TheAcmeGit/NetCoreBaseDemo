<template>
  <div class="app-container">
    <div class="filter-container">
      <el-form v-model="queryList" :inline="true">
        <el-form-item label="部门名称">
          <el-input v-model="queryList.departmentName" placeholder="部门名称" class="filter-item" />
        </el-form-item>
        <el-form-item label="部门状态">
          <el-select v-model="queryList.departmentStatus">
            <el-option v-for="item in enumTypes.departmentStatusTypes" :key="item.key" :label="item.value" :value="item.key" />
          </el-select>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" icon="el-icon-search">查询</el-button>
          <el-button type="success" icon="el-icon-edit" @click="handleShowDialog('create')">新增</el-button>
        </el-form-item>

      </el-form>
    </div>
    <div class="block">
      <!-- 表格数据 -->
      <el-table
        :data="tableData"
        border
        fit
        highlight-current-row
        @select="handleSelect"
      >
        <el-table-column type="selection" width="40" align="center" />
        <el-table-column prop="departmentName" label="部门名称" />
        <el-table-column prop="departmentStatus" label="部门状态" :formatter="departmentStatusFormatter" />
        <el-table-column label="创建时间">
          <template slot-scope="scope">
            {{ scope.row.createtime }}
          </template>
        </el-table-column>

        <el-table-column label="操作">
          <template slot-scope="scope">
            <el-button size="mini" round @click="handleShowDialog('edit',scope.row)">编辑</el-button>
            <el-button type="danger" size="mini" round>删除</el-button>
          </template>
        </el-table-column>
      </el-table>
      <!-- 分页 -->
      <el-pagination
        :current-page="queryList.pageIndex"
        :page-sizes="[10, 20, 30, 40]"
        :page-size="queryList.pageSize"
        layout="total, sizes, prev, pager, next, jumper"
        :total="total"
        @size-change="handleSizeChange"
        @current-change="handleCurrentChange"
      />
    </div>

    <!-- 弹框 -->
    <div>
      <el-dialog
        title="提示"
        :visible.sync="dialogConfig.show"
        width="50%"
        center
      >
        <el-form ref="form" :model="dialogConfig.form" label-width="80px">
          <el-col :span="24">
            <el-col :span="12">
              <el-form-item label="部门名称">
                <el-input v-model="dialogConfig.form.departmentName" placeholder="部门名称" />
              </el-form-item>
            </el-col>
            <el-col :span="12">
              <el-form-item label="部门状态">
                <el-select v-model="dialogConfig.form.departmentStatus">
                  <el-option v-for="item in enumTypes.departmentStatusTypes" :key="item.key" :label="item.value" :value="item.key" />
                </el-select>
              </el-form-item>
            </el-col>
          </el-col>
        </el-form>
        <div slot="footer" class="dialog-footer">

          <el-button @click="dialogFormVisible = false">
            Cancel
          </el-button>
          <el-button type="primary" @click="dialogConfig.dialogStatus==='create'?createData():updateData()">
            Confirm
          </el-button>
        </div>
      </el-dialog>
    </div>
  </div>
</template>
<script>
import { getList, insert, remove, update } from '@/api/sysDepartment'
export default {
  data() {
    return {
      tableData: null,
      total: 0,
      queryList: {
        pageIndex: 1,
        pageSize: 10,
        departmentName: null,
        departmentStatus: null
      },

      dialogConfig: {
        form: {
          departmentName: '',
          departmentStatus: 0
        },
        show: false,
        dialogStatus: ''
      },

      enumTypes: {
        departmentStatusTypes: [
          { key: 0, value: '不可用' },
          { key: 1, value: '可用' }
        ]
      }

    }
  },
  created: function() {
    getList(this.queryList).then(res => {
      this.tableData = res.data.tableData
      this.total = res.data.total
    })
  },
  methods: {
    handleSelect: function() {

    },
    resetForm: function() {
      this.dialogConfig.form = {
        departmentName: '',
        departmentStatus: 0
      }
    },
    handleShowDialog: function(actionType, rowData) {
      this.dialogConfig.dialogStatus = actionType
      this.dialogConfig.show = true
      console.log('rowdata', rowData)
      if (rowData != null) {
        this.dialogConfig.form = Object.assign({}, rowData)
      } else {
        this.resetForm()
      }
    },
    // 删除操作
    createData: function() {
      insert(this.dialogConfig.form).then(res => {
        this.$notify({
          duration: 2000,
          title: 'Success',
          message: '新增完成',
          type: 'success'
        })
      })
      this.dialogConfig.dialogStatus = ''
      this.dialogConfig.show = false
    },
    // 更新操作
    updateData: function() {
      update(this.dialogConfig.form).then(res => {
        this.$notify({
          title: 'Suucess',
          message: '编辑完成',
          duration: 2000,
          type: 'success'
        })
        this.dialogConfig.dialogStatus = ''
        this.dialogConfig.show = false
      })
    },
    // 删除操作
    deleteData: function() {
      remove({ id: '' })
    },
    // 部门状态格式化
    departmentStatusFormatter: function(row, column, cellValue, index) {
      if (row.departmentStatus === 0) {
        return '不可用'
      } else if (row.departmentStatus === 1) {
        return '可用'
      } else {
        return '未知'
      }
    },
    // 分页处理
    handleSizeChange: function(pageSize) {
      this.queryList.pageSize = pageSize
      this.queryList.pageIndex = 1
      getList(this.queryList).then(res => {
        this.tableData = res.data.tableData
        this.total = res.data.total
      })
    },
    handleCurrentChange: function(pageIndex) {
      this.queryList.pageIndex = pageIndex
      getList(this.queryList).then(res => {
        this.tableData = res.data.tableData
        this.total = res.data.total
      })
    }
  }
}
</script>
