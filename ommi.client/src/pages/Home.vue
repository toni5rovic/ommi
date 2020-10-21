<template>
  <div class="home">
    <h1 class="header">Welcome To Ommi</h1>
    <img alt="logo" src="../assets/ommi-logo.jpg">
    <div>Login if you have an account or register to continue</div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({
})
export default class Home extends Vue {

}
</script>

<style scoped>
.header{
  font-size: 150px;
}
</style>
