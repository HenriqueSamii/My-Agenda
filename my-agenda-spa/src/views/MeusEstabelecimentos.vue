<template>
  <div id="MeuEstabelecimento">
    <router-link style="margin:1.5em;" tag="button" :to="{name:'CriarEstabelecimento'}">Novo Estabelecimento</router-link>
    <div class="cardList">
      <div class="carde" v-for="esta of this.agendaUsu" :key="esta">
        <CardEstabelecimentoSimples v-bind:estabelecimentoContent="esta" />
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import Estabelecimento from "@/services/estabelecimento";
import CardEstabelecimentoSimples from "@/components/CardEstabelecimentoSimples.vue";
export default {
  name: "HomeLogado",
  data: function(){
    return{
      agendaUsu:[]
    };
  },computed: {
    ...mapGetters(["usuarioKey"])
  },
  mounted(){
    Estabelecimento.estabelecimentosDeUsuario(this.usuarioKey).then((result) => {
      var agendaOrdenadada = result.data['usuariosBlocosDaAgenda']
      //console.log(agendaOrdenadada)

      // function custom_sort(a, b) {
      //   return new Date(a.BlocoDaAgenda.Comeco).getTime() - new Date(b.BlocoDaAgenda.Comeco).getTime();
      // }

      // this.agendaUsu = agendaOrdenadada.sort(custom_sort);
      this.agendaUsu = agendaOrdenadada;
      //console.log(this.agendaUsu[0])
    }).catch((err) => {
      console.log(err)
    });
  },
  components: {
    CardEstabelecimentoSimples
  }
};
</script>
<style>
.criar{
  margin: 0.5em;
}
</style>