<template>
  <div id="criarConta">
    <LoginECreate v-bind:isLogin="false" pageTitle="Criar Conta" />
  </div>
</template>

<script>
import LoginECreate from "@/components/LoginECreate.vue";
export default {
  name: "CriarConta",
  data: function() {
    return {};
  },
  components: {
    LoginECreate
  }
};
</script>
<style>
#criarConta{
  height: 100vh;
}
</style>