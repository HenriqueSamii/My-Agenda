<template>
  <div id="loginECreate">
    <h1>{{pageTitle}}</h1>
    <p v-if="erro != '' || erro != null">{{erro}}</p>
    <form v-on:submit.prevent="metodoFormSubmit">
      <div v-if="!isLogin" class="form-group">
        <label for="exampleInputEmail1">Nome</label>
        <input
          v-model="usu.username"
          ref="nome"
          type="text"
          class="form-control"
          id="exampleInputNome1"
          aria-describedby="nomeHelp"
          placeholder="Entere com o seu Nome"
          required
        />
      </div>
      <div class="form-group">
        <label for="exampleInputEmail1">Email</label>
        <input
          v-model="usu.email"
          ref="email"
          type="email"
          class="form-control"
          id="exampleInputEmail1"
          aria-describedby="emailHelp"
          placeholder="Entere com o seu email"
          required
        />
      </div>
      <div class="form-group">
        <label for="exampleInputPassword1">Password</label>
        <input
          v-model="usu.password"
          ref="password"
          type="password"
          class="form-control"
          id="exampleInputPassword1"
          placeholder="Entere com o sua Password"
          required
        />
      </div>
      <button v-if="isLogin" type="submit" class="btn btn-primary">Logar</button>
      <button v-else type="submit" class="btn btn-primary">Criar Conta</button>
    </form>
  </div>
</template>

<script>
import { mapActions } from "vuex";
import Usu from "@/services/usuarios";
//import { AxiosResponse, AxiosError } from 'axios'
//import { mapGetters, mapActions } from "vuex";
export default {
  name: "loginECreate",
  props: {
    pageTitle: String,
    isLogin: Boolean
  },
  data: function() {
    return {
      erro: "",
      usu:{
        email: "",
        password: "",
        username: ""
      },
    };
  },
  methods: {
    ...mapActions(["login", "createUsuario"]),
    metodoFormSubmit: function() {
      this.erro == "";
      if (this.isLogin) {
        this.metodoLogin();
      } else {
        this.metodoCriarConta();
      }
    },
    metodoLogin: function() {
      //this.erro = "Usuario nao existe";
      Usu.logar(this.usu).then(resposta => {
        this.login(resposta.data['token']);
        //console.log(resposta.data['token'])
        this.$router.push({ name: "Home" });
      })
      .catch((reason) => {
        if (reason.status === 400) {
          this.erro = "Dados inorrectos, tente novamente"
        } else {
          this.erro = "Erro interno, tente mais tarde"
        }
        //console.log(reason.message)
      });
    },
    metodoCriarConta: function() {
      Usu.criar(this.usu).then(resposta => {
        this.erro = "Usuario criado ";
        console.log(resposta)
      })
      .catch((reason) => {
        if (reason.status === 400) {
          this.erro = "Dados inorrectos, tente novamente"
        } else {
          this.erro = "Erro interno, tente mais tarde"
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