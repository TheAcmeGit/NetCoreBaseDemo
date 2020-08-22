<template>
  <div class="app-container">

    <div class="filter-container">
      <el-form :inline="true" :model="queryList" class="demo-form-inline">
        <el-form-item label="用户名">
          <el-input v-model="queryList.userName" placeholder="用户名" />
        </el-form-item>
        <el-form-item label="性别">
          <el-select v-model="queryList.gender" placeholder="请选择性别">
            <el-option v-for="item in genderTypes" :key="item.key" :label="item.display_name" :value="item.key" />
          </el-select>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="onSubmit">查询</el-button>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="HandleAdd">新增</el-button>
        </el-form-item>
      </el-form>

    </div>
    <!-- table 分页显示 -->
    <div class="block">
      <el-table
        :data="tableData"
        style="width: 100%"
        border
        fit
        highlight-current-row
        @select="handleSelect"
      >
        <el-table-column
          type="selection"
          width="55"
        />
        <el-table-column
          prop="userName"
          label="用户名"
          width="100"
        />
        <el-table-column
          prop="password"
          label="密码"
          width="100"
        />
        <el-table-column
          prop="realName"
          label="姓名"
          width="100"
        />
        <el-table-column
          label="性别"
          width="80"
          :formatter="genderFormatter"
        />
        <el-table-column
          prop="age"
          label="年龄"
          width="80"
        />
        <el-table-column
          prop="userStatus"
          label="用户状态"
          width="90"
          :formatter="userStatusFormatter"
        />
        <el-table-column
          prop="idCard"
          label="身份证号码"
          width="200"
        />
        <el-table-column
          prop="phone"
          label="手机"
          width="130"
        />
        <el-table-column
          prop="address"
          label="地址"
          show-overflow-tooltip
        />

        <el-table-column
          label="创建时间"
          width="200"
        >
          <template slot-scope="scope">
            <i class="el-icon-time" />
            <span style="margin-left: 10px">{{ scope.row.createTime }}</span>
          </template>
        </el-table-column>
        <el-table-column label="操作" width="180">
          <template slot-scope="scope">
            <el-button
              size="mini"
              @click="handleEdit(scope.$index, scope.row)"
            >编辑</el-button>
            <el-button
              size="mini"
              type="danger"
              @click="handleDelete(scope.$index, scope.row)"
            >删除</el-button>
          </template>
        </el-table-column>
      </el-table>

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
        :visible.sync="centerDialogVisible"
        width="50%"
        center
      >
        <el-form ref="form" :model="form" label-width="80px">
          {{ dialogStatus }}
          <el-col :span="24">
            <el-col :span="12">
              <el-form-item label="用户名">
                <el-input v-model="form.userName" />
              </el-form-item>
            </el-col>
            <el-col :span="12">
              <el-form-item label="姓名">
                <el-input v-model="form.realName" />
              </el-form-item>
            </el-col>
          </el-col>
          <el-col :span="24">
            <el-col :span="12">
              <el-form-item label="身份证号">
                <el-input v-model="form.idCard" />
              </el-form-item>
            </el-col>
            <el-col :span="12">
              <el-form-item label="手机号码">
                <el-input v-model="form.phone" />
              </el-form-item>
            </el-col>
          </el-col>

          <el-col :span="24">
            <el-col :span="12">
              <el-form-item label="性别">
                <el-select v-model="form.gender" placeholder="性别" class="filter-item">
                  <el-option
                    v-for="item in genderTypes"
                    :key="item.key"
                    :label="item.display_name"
                    :value="item.key"
                  />

                </el-select>
              </el-form-item>
            </el-col>
            <el-col :span="12">
              <el-form-item label="用户状态">
                <el-select v-model="form.userStatus" placeholder="用户状态" class="filter-item">
                  <el-option
                    v-for="item in userStatus"
                    :key="item.key"
                    :label="item.display_name"
                    :value="item.key"
                  />
                </el-select></el-form-item>
            </el-col>
          </el-col>

          <el-col :span="24">
            <el-form-item label="地址">
              <el-input v-model="form.address" />
            </el-form-item>
          </el-col>
        </el-form>
        <div slot="footer" class="dialog-footer">

          <el-button @click="dialogFormVisible = false">
            Cancel
          </el-button>
          <el-button type="primary" @click="dialogStatus==='create'?createData():updateData()">
            Confirm
          </el-button>
        </div>
      </el-dialog>
    </div>
  </div>
</template>

<script>
import { getList, update, insert, remove } from '@/api/sysAccount'

export default {
  data() {
    return {
      tableData: null,
      total: 400,
      queryList: {
        pageIndex: 1,
        pageSize: 10,
        userName: null,
        gender: null
      },
      genderTypes: [
        { key: '', display_name: '请选择性别' },
        { key: 0, display_name: '未知' },
        { key: 1, display_name: '女士' },
        { key: 2, display_name: '男士' }
      ],
      userStatus: [
        { key: 0, display_name: '禁用' },
        { key: 1, display_name: '启用' }
      ],
      centerDialogVisible: false,
      dialogStatus: '',
      form: {
        userName: '',
        realName: '',
        gender: '',
        age: '',
        userStatus: false,
        idCard: '',
        phone: '',
        address: ''
      }
    }
  },
  created: function() {
    getList(this.queryList).then(res => {
      console.log(res.data)
      this.tableData = res.data.tableData
      this.total = res.data.total
    })
  },
  methods: {
    resetForm() {
      this.form = {
        id: null,
        userName: '',
        realName: '',
        gender: 0,
        age: '',
        userStatus: 1,
        idCard: '',
        phone: '',
        address: ''
      }
    },
    indexMethod(index) {
      return index * 2
    },
    handleSizeChange: function(num) {
      this.queryList.pageSize = num
      getList(this.queryList).then(res => {
        console.log(res.data)
        this.tableData = res.data.tableData
        this.total = res.data.total
      })
    },
    handleCurrentChange: function(num) {
      this.queryList.pageIndex = num
      getList(this.queryList).then(res => {
        console.log(res.data)
        this.tableData = res.data.tableData
        this.total = res.data.total
      })
    },
    handleSelect: function(selection, row) {
      this.$message(row.userName)
      console.log('handleSelect', row)
    },
    onSubmit: function() {
      getList(this.queryList).then(res => {
        console.log(res.data)
        this.tableData = res.data.tableData
        this.total = res.data.total
      })
    },
    HandleAdd: function() {
      this.dialogStatus = 'create'
      this.resetForm()
      this.centerDialogVisible = true
    },
    handleEdit: function(index, row) {
      this.form = Object.assign({}, row) // copy obj

      this.dialogStatus = 'edit'
      this.centerDialogVisible = true
    },
    createData: function() {
      insert(this.form).then(res => {
        if (res.data != null) {
          this.dialogStatus = ''
          this.centerDialogVisible = false
          this.form.id = res.data
          var rowData = Object.assign({}, this.form)
          this.tableData.splice(0, 0, rowData)
          this.$notify({
            title: 'Success',
            message: '新增成功',
            type: 'success',
            duration: 2000
          })
        }
      })
      this.$message('新增')
    },
    updateData: function() {
      const tempData = Object.assign({}, this.form)

      console.log('form', this.form)

      update(tempData).then(res => {
        if (res.data === 1) {
          const index = this.tableData.findIndex(v => v.id === this.form.id)

          console.log('index', index)

          this.tableData.splice(index, 1, this.form)

          this.dialogStatus = ''
          this.centerDialogVisible = false
          this.$notify({
            title: 'Success',
            message: '更新成功',
            type: 'success',
            duration: 2000
          })
        }
      })
      this.$message('编辑')
    },
    handleDelete: function(index, row) {
      const delteIndex = this.tableData.findIndex(f => f.id === row.id)
      remove({ id: row.id }).then(res => {
        if (res.data === 1) {
          this.tableData.splice(delteIndex, 1)
          this.$notify({
            title: 'Success',
            message: '删除完成',
            type: 'success',
            duration: 2000
          })
        }
      })
    },
    genderFormatter: function(row, column, cellValue, index) {
      if (row.gender === 1) {
        return '女士'
      } else if (row.gender === 2) {
        return '男士'
      } else {
        return '未知'
      }
    },
    userStatusFormatter: function(row, column, cellValue, index) {
      if (cellValue === 0) {
        return '停用'
      } else {
        return '可用'
      }
    }
  }
}
</script>
