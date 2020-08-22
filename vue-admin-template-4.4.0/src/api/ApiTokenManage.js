import request from '@/utils/request'

export function login(data) {
  return request({
    url: 'ApiTokenManage',
    method: 'get',
    data
  })
}

export function getInfo() {
  return request({
    url: '/ApiTokenManage/id',
    method: 'get'
  })
}

export function logout() {
  return request({
    url: '/vue-admin-template/user/logout',
    method: 'post'
  })
}
