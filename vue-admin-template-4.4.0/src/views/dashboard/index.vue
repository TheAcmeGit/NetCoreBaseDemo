<template>
  <div class="dashboard-container">
    <div class="dashboard-text">name: {{ name }}</div>
    <button @click="getInfo">获取用户信息</button>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
import { getInfo } from '@/api/ApiTokenManage'

export default {
  name: 'Dashboard',
  computed: {
    ...mapGetters([
      'name'
    ])
  },
  methods: {
    getInfo: function() {
      getInfo().then(res => {
        console.log(res)
      })
    }
  }
}
</script>

<style lang="scss" scoped>
.dashboard {
  &-container {
    margin: 30px;
  }
  &-text {
    font-size: 30px;
    line-height: 46px;
  }
}
</style>
