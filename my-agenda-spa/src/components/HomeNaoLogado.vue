  
<template>
  <div class="naoLogado">
    <div style="margin-top:1em" class="divisorias">
      <h2 class="card-heading  text-center my-auto" tabindex="5">O que é a My Agenda?</h2>
      <div class="row justify-content-center imgText">
        <div class="col-xs-6 img">
          <img
          tabindex="6"
            src="https://i.mlcdn.com.br/portaldalu/fotosconteudo/68959.jpg"
            alt="Agenda de papel com uma pessoa escrevendo"
          />
        </div>
        <div class="col-xs-6 text">
          <p tabindex="7">
            orem ipsum dolor sit amet, consectetur adipiscing elit. Integer sit amet dolor vel metus porttitor euismod quis vel libero. Suspendisse id risus nulla. Aliquam erat volutpat. Duis eu velit mollis, posuere lorem a, pharetra nunc. In vehicula lacus non libero iaculis venenatis. Sed malesuada metus ipsum. Duis sagittis pharetra ex at iaculis.
<br>
Aliquam congue magna eleifend leo sagittis efficitur. Nulla et velit sit amet metus rhoncus suscipit vitae eu eros. Proin faucibus ornare metus, id vestibulum arcu condimentum quis. Nulla facilisi. Mauris fermentum ullamcorper pretium. Sed mattis, felis sit amet egestas sagittis, odio ligula condimentum sem, sed commodo lacus risus quis leo. In aliquet sit amet erat ac vehicula. Quisque nisl nunc, viverra a metus id, commodo posuere purus. Etiam a cursus leo, sit amet mollis odio. Pellentesque finibus tellus ut velit bibendum laoreet. Quisque accumsan, nulla at posuere luctus, lacus lorem sollicitudin purus, et imperdiet nunc lorem nec ex. Aliquam id pellentesque risus. Proin volutpat, diam at mollis convallis, nibh lacus faucibus tellus, ut venenatis arcu leo eu dolor. Fusce in tellus consequat, sodales neque a, blandit enim. Curabitur blandit porttitor ex, nec finibus tellus tristique faucibus. Praesent sed est facilisis lectus sodales lobortis.
<br>
Integer aliquet aliquam lectus nec fermentum. Sed vel nulla vitae leo mollis viverra vitae ut magna. Orci varius natoque penatibus et magnis dis parturient monte
          </p>
        </div>
      </div>
    </div>

    <div style="margin-top:5em" class="divisorias">
      <h2 class="card-heading  text-center my-auto" tabindex="8">Sobre o criador</h2>
      <div class="row justify-content-center imgText">
        <div class="col-xs-6 img">
          <img
          tabindex="9"
            src="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRUYKLul0Ke5oAAmj6j3dtXqo52adPNlh6moNPv9zrrWYfdhDum"
            alt="foto de henrique samii, o barba"
          />
        </div>
        <div class="col-xs-6 text" tabindex="10">
          <p>Cara mais bonito da façe da faculdade. Sua modestidade não encontra oposição nesta dimensão ou outras e sua barba da um +1 em Carisma.</p>
          <p>
            orem ipsum dolor sit amet, consectetur adipiscing elit. Integer sit amet dolor vel metus porttitor euismod quis vel libero. Suspendisse id risus nulla. Aliquam erat volutpat. Duis eu velit mollis, posuere lorem a, pharetra nunc. In vehicula lacus non libero iaculis venenatis. Sed malesuada metus ipsum. Duis sagittis pharetra ex at iaculis.
<br>
Aliquam congue magna eleifend leo sagittis efficitur. Nulla et velit sit amet metus rhoncus suscipit vitae eu eros. Proin faucibus ornare metus, id vestibulum arcu condimentum quis. Nulla facilisi. Mauris fermentum ullamcorper pretium. Sed mattis, felis sit amet egestas sagittis, odio ligula condimentum sem, sed commodo lacus risus quis leo. In aliquet sit amet erat ac vehicula. Quisque nisl nunc, viverra a metus id, commodo posuere purus. Etiam a cursus leo, sit amet mollis odio. Pellentesque finibus tellus ut velit bibendum laoreet. Quisque accumsan, nulla at posuere luctus, lacus lorem sollicitudin purus, et imperdiet nunc lorem nec ex. Aliquam id pellentesque risus. Proin volutpat, diam at mollis convallis, nibh lacus faucibus tellus, ut venenatis arcu leo eu dolor. Fusce in tellus consequat, sodales neque a, blandit enim. Curabitur blandit porttitor ex, nec finibus tellus tristique faucibus. Praesent sed est facilisis lectus sodales lobortis.
<br>
Integer aliquet aliquam lectus nec fermentum. Sed vel nulla vitae leo mollis viverra vitae ut magna. Orci varius natoque penatibus et magnis dis parturient monte
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "HomeNaoLogado",
  methods:{
    alerta: function(funcao){
      alert(funcao + ' ainda em em teste')
    }
  }
};
</script>

<style>
.card-heading{
    padding-bottom: 0.25em;
};
 .divisorias{
  padding-top: 0.9em;
  padding-bottom: 0.9em;
}
#formulario, #ProcurePor{
  text-align: center;
}
.card{
  margin: 0.5em,0,0.5em,0;
  padding: 0.5em;
}
.imgText{
    float: none;
    margin: 0 auto;
 }
.naoLogado div.img img{
    width: 40em;
    position: relative;
   
}
.naoLogado div.text{
	padding: 20px;
	width: 50%;
}
.naoLogado, #formulario{
  padding-top: 0.5em;
}
a:link {
  color: rgba(108, 0, 170, 0.884);
}
a:visited {
  color: rgb(117, 78, 117);
}
@media (orientation: portrait) {
  /* For vertical viewports */
  .naoLogado div.img img{
    width: 80%;
    float: none;
    display: block;
    margin: 0 auto;
}
.naoLogado div.text{
	padding: 20px;
	width: 80%;
}
}
 @media only screen and (max-device-width: 768px){
    .naoLogado div.img img{
    width: 80%;
    float: none;
    display: block;
    margin: 0 auto;
}
} 
</style>