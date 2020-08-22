import request from '@/utils/request'

export function getList(data) {
  return request({
    url: '/sysaccount',
    method: 'get',
    params: data
  })
}
export function insert(data) {
  return request({
    url: '/sysaccount',
    method: 'post',
    data: data
  })
}
export function update(data) {
  return request({
    url: '/sysaccount',
    method: 'put',
    data: data
  })
}
export function remove(data) {
  return request({
    url: '/sysaccount',
    method: 'delete',
    params: data
  })
}

