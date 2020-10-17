<template>
<v-container>
  <v-row align="center" justify="center">
    <v-col cols="12" sm="6">
      <v-layout align-center column justify-center>
        <v-card class>
          <v-card-text>
            <v-text-field label="Username" v-model="registerRequest.username" />
            <v-text-field label="Password" type="password" v-model="registerRequest.password" />
          </v-card-text>
          <v-card-actions>
            <v-spacer />
            <v-btn @click="onSubmit">Log In</v-btn>
          </v-card-actions>
          <v-alert type="error" v-if="loginFailure">Wrong credentials, try again</v-alert>
        </v-card>
      </v-layout>
    </v-col>
  </v-row>
</v-container>
</template>

<script src='./login-page.ts'></script>
