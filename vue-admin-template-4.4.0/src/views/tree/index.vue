<template>
  <div>
    <el-select v-model="obj.selectValue" placeholder="请选择">
      <el-option
        v-for="item in options"
        :key="item.value"
        :label="item.label"
        :value="item.value"
        :disabled="item.disabled"
      />
    </el-select>
    <button @click="test">点击更换只</button>
  </div>

</template>

<script>
export default {
  data() {
    return {
      obj: {
        selectValue: null
      },

      options: [{
        value: '选项1',
        label: '黄金糕'
      }, {
        value: '选项2',
        label: '双皮奶',
        disabled: true
      }, {
        value: '选项3',
        label: '蚵仔煎'
      }, {
        value: '选项4',
        label: '龙须面'
      }, {
        value: '选项5',
        label: '北京烤鸭'
      }],
      value: ''
    }
  },
  methods: {

    test: function() {
      this.obj.selectValue = '选项4'
    }
  }
}
</script>
