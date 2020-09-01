<template>
  <div id="app">
    <Header title="My Agenda" />
    <div id="corpo">
      <router-view/>
    </div>
  </div>
</template>

<script>
//import Main from "./components/Main.vue";
//import CartaoFilme from "./components/CartaoFilme.vue";
import Header from "./components/Header.vue";
export default {
  name: "App",
  data: function(){
    return{};
  },
  components: {
    Header
  }
};
</script>

<style>
 #app{
  /* background-image: url("./assets/dungeonWall.jpg");
  background-repeat: repeat; */
  width:100%; 
  margin:0;
  margin-top: 3.5em;
  background-color:  rgb(243, 243, 243) ;/*#f4c430;c4d0c4;*/
}
#corpo{
  width: 90%;
  margin:0 auto;
  background-color: #d6d6c5; 
  padding-bottom: 2em;
}
</style>