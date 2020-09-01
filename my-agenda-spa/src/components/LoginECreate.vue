<template>
  <div id="loginECreate">
    <h1>{{pageTitle}}</h1>
    <p v-if="erro != '' || erro != null">{{erro}}</p>
    <form v-on:submit.prevent="metodoFormSubmit">
      <div v-if="!isLogin" class="form-group">
        <label for="exampleInputEmail1">Nome</label>
        <input
          v-model="nome"
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
          v-model="email"
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
          v-model="password"
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
      email: "",
      password: "",
      nome: ""
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
      //TODO: Fazer funcao de Login
      //console.log(this.$refs.email.value + " " + this.$refs.password.value + " login");
      if (this.$store.getters.usuarioEmailExists(this.email)) {
        let user = this.$store.getters.usuarioByEmail(this.email);
        if (user.password == this.password) {
          this.login(user.id);
          this.$router.push({ name: "Home" });
        } else {
          this.erro = "Passwor errada";
        }
      } else {
        this.erro = "Usuario nao existe";
      }
    },
    metodoCriarConta: function() {
      //TODO: Fazer funcao de Criar Conta
      //console.log(this.$refs.email.value + " " + this.$refs.password.value + " criar conta");
      if (this.$store.getters.usuarioEmailExists(this.email)) {
        this.erro = "Esse email ja esta sendo uasdo";
      } else {
        this.createUsuario({
          id: 0,
          nome: this.nome,
          email: this.email,
          password: this.password
        });
        this.nome = "";
        this.email = "";
        this.password = "";
        this.erro = "Usuario criado com sucesso";
        //this.$router.push({ name: "Home" });
      }
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