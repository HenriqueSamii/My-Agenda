<template>
  <div id="loginECreate">
    <h1>Novo Estabelecimeno</h1>
    <p v-if="erro != '' || erro != null">{{erro}}</p>
    <form v-on:submit.prevent="metodoCriarEstabelecimento">
      <div class="form-group">
        <label for="exampleInputNome1">Nome</label>
        <input
          v-model="estab.nome"
          ref="nome"
          type="text"
          class="form-control"
          id="exampleInputNome1"
          aria-describedby="nomeHelp"
          placeholder="Entere com o nome do estabelecimento"
          required
        />
      </div>
      <div class="form-group">
        <label for="exampleInputDescricao1">Descricao</label>
        <input
          v-model="estab.descricao"
          ref="descricao"
          type="text"
          class="form-control"
          id="exampleInputDescricao1"
          aria-describedby="emailHelp"
          placeholder="Entere com a descricao do estabelecimento"
          required
        />
      </div>
      <button type="submit" class="btn btn-primary">Criar</button>
    </form>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import Esta from "@/services/estabelecimento";
export default {
  name: "loginECreate",
  props: {
    pageTitle: String,
    isLogin: Boolean
  },
  data: function() {
    return {
      erro: "",
      estab:{
        nome: "",
        descricao: ""},
    };
  },
  computed: {
    ...mapGetters(["usuarioKey"])
  },
  methods: {
    metodoCriarEstabelecimento: function() {
        //console.log(this.usuarioKey)
      Esta.criar(this.usuarioKey,this.estab).then(resposta => {
        this.erro = "Estabelecimento criado ";
        console.log(resposta)
      })
      .catch((reason) => {
        if (reason.status === 400) {
          this.erro = "Dados inorrectos, tente novamente" + status
        } else {
          this.erro = "Erro interno, tente mais tarde " + status
        }
        //console.log(reason.message)
      });
    }
  }
};
</script>
<style>
#loginECreate {
  width: 60%;
  float: none;
  margin: 0 auto;
  padding-top: 2.5em;
  padding-bottom: 2.5em;
}
</style>