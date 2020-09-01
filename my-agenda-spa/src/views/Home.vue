<template>
  <div class="home">
    <HomeLogado v-if="this.isUsuarioLogado"/>
    <HomeNaoLogado v-else/>
  </div>
</template>

<script>
import { mapGetters} from "vuex";
// @ is an alias to /src
import HomeNaoLogado from "@/components/HomeNaoLogado.vue"; 
import HomeLogado from "@/components/HomeLogado.vue"; 
export default {
  name: "Home",
  components: {
    //HelloWorld
    HomeNaoLogado,
    HomeLogado
  },
  computed: {
    ...mapGetters(["isUsuarioLogado"])
  }
};
</script>
