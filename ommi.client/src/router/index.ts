import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '../pages/Home.vue'
import Login from '../pages/login/login-page.vue'
import Rooms from '../pages/rooms/rooms.vue'
import CreateRoom from '../pages/create-room/create-room.vue'
import Board from '../pages/board/board.vue'
Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/login',
    name: 'Login',
    component: Login
  },
  {
    path: '/rooms',
    name: 'Rooms',
    component: Rooms
  },
  {
    path: '/create-room',
    name: 'CreateRoom',
    component: CreateRoom
  },
  {
    path: '/board',
    name: 'Board',
    component: Board
  }
]

const router = new VueRouter({
  routes
})

export default router
