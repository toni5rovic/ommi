<template>
  <div>
    <v-app-bar app elevate-on-scroll color="primary" dark style="z-index: 4;">
      <v-toolbar-title link @click="root" style="cursor:pointer;">Ommi</v-toolbar-title>
      <v-toolbar-title v-if="this.signedin()" link @click="rooms" style="cursor:pointer;" class="navmenu-item">Rooms</v-toolbar-title>
      <v-spacer />
      <v-btn lass="button-class" v-if="this.signedin() === false" @click="goToRegister()">
        Register
        <v-icon>mdi-account-plus</v-icon>
      </v-btn>
      <v-btn class="button-class" v-if="this.signedin() === false" @click="goToLogin()">
        Log in
        <v-icon>mdi-login</v-icon>
      </v-btn>
      <v-btn class="button-class" v-else @click="logout()">
        Log out
        <v-icon>mdi-logout</v-icon>
      </v-btn>
    </v-app-bar>
  </div>
</template>
<script src="./navmenu.ts"></script>

<style scoped>
.button-class{
  margin-left: 10px;
  margin-right: 10px;
}
.navmenu-item{
  margin-left: 15px;
}
</style>
