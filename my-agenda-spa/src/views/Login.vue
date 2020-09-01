<template>
  <div id="login">
    <LoginECreate v-bind:isLogin="true" pageTitle="Login" />
  </div>
</template>

<script>
import LoginECreate from "@/components/LoginECreate.vue";
export default {
  name: "Login",
  data: function() {
    return {};
  },
  components: {
    LoginECreate
  }
};
</script>
<style>
#login{
  height: 100vh;
}
</style>