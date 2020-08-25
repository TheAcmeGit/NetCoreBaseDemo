import request from '@/utils/request'

export function getList(data) {
  return request({
    url: '/sysnavmenu',
    method: 'get',
    params: data
  })
}
export function insert(data) {
  return request({
    url: '/sysnavmenu',
    method: 'post',
    data: data
  })
}
export function update(data) {
  return request({
    url: '/sysnavmenu',
    method: 'put',
    data: data
  })
}
export function remove(data) {
  return request({
    url: '/sysnavmenu',
    method: 'delete',
    params: data
  })
}

