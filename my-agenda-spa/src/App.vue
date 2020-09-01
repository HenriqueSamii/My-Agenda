<template>
  <div id="app">
    <Header title="My Agenda" />
    <div id="corpo">
      <router-view/>
    </div>
  </div>
</template>

<script>
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
  background-color:  #f8e7ca ;/*#f4c430;c4d0c4;*/
}
#corpo{
  width: 90%;
  margin:0 auto;
  background-color: #f1f1ee; 
  padding-bottom: 2em;
}
</style>