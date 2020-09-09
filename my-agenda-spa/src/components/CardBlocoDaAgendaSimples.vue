<template>
  <div class="container">
    <div class="card">
      <h2 class="card-title">Data: {{this.agendaContent.BlocoDaAgenda.Comeco}}</h2>
      <div class="card-body">
        <p class="card-text sideText">Cliente: {{usuarioById(this.agendaContent.Usuario.Email)}}</p>
        <p class="card-text sideText">Prestador: {{usuarioById(this.agendaContent.BlocoDaAgenda.Prestadores[0].Conta.Email)}}</p>
        <p class="card-text sideText">Local: {{this.agendaContent.BlocoDaAgenda.Local.Nome}}</p>
        <!-- <p class="card-text sideText">Duração: {{this.BlocoDaAgenda.Servicos}}</p> -->
        <p class="card-text mainText" v-if="this.agendaContent.corpo != '' || this.agendaContent.corpo != null">{{this.BlocoDaAgenda.Servicos}}</p>
      </div>
      <!-- <dir class="butoesDiv">
        <button
          class="btn btn-danger btnDeletar"
          type="button"
          v-on:click="cancelarBloco"
        >Canselar</button>
      </dir> -->
    </div>
  </div>
</template>

<script>
// import { mapGetters} from "vuex";
export default {
  name: "loginECreate",
  props: {
    agendaContent: Object
  },
  data: function() {
    return {};
  },
  computed: {
    // ...mapGetters(["usuarioKey"])
  },
  methods: {
    // cancelarBloco: function() {
    //   this.deletePost(this.postContent.id);
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