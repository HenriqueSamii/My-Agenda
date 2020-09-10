<template>
  <div class="container">
    <div class="card">
      <h2 class="card-title">{{this.estabelecimentoContent.nome}}</h2>
      <div class="card-body">
        <p class="card-text sideText">Descrição: {{this.estabelecimentoContent.descricao}}</p>
     </div>
      <dir class="butoesDiv">
        <router-link
          style="margin:0.5em;"
          tag="button"
          class="btn btn-primary"
          type="submit"
          :to="{name:'EstabelecimentoAgenda', params: { idEsta: this.estabelecimentoContent.id } }"
        >Criar Funcionario</router-link>
        <router-link
          style="margin:0.5em;"
          tag="button"
          class="btn btn-primary"
          type="submit"
          :to="{name:'EstabelecimentoAgenda', params: { idEsta: this.estabelecimentoContent.id } }"
        >Ver Agenda</router-link>
      </dir>
    </div>
  </div>
</template>

<script>
// import { mapGetters} from "vuex";
export default {
  name: "cardEstaSimples",
  props: {
    estabelecimentoContent: Object
  },
  data: function() {
    return {};
  },
  computed: {
    // ...mapGetters(["usuarioKey"])
  },
  mounted(){
    console.log(this.estabelecimentoContent)
  },
  methods: {
    // criarFuncionario: function() {
    //     this.$router.push({name: 'CriarFuncionario', params: { idEst: this.idEstabelecimento }})
    // },
    // verAgenda: function() {
    //     this.$router.push({name: 'EstabelecimentoAgenda', params: { idEst: this.idEstabelecimento }})
    // },
  }
};
</script>
<style>
.container {
  width: 70%;
  background-color: transparent;
}
/* .btnEditar,
.btnDeletar {
  width: 50%;
}
.butoesDiv {
  padding: 0%;
  margin: 0%;
  display: inline-block;
} */
.mainText{
  font-size: 1.5em;
}
.sideText{
  font-weight: bold;
}
.card{
  background-color: antiquewhite;
}
</style>