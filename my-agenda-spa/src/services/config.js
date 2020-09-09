import axios from 'axios'
//import VueAxios from 'vue-axios'
 
//Vue.use(VueAxios, axios)
export const  localhost = 'http://localhost:5000/api/'
export const  http = axios.create({
    baseURL: localhost
})