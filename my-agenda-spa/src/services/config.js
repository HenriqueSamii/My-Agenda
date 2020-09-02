import axios from 'axios'
//import VueAxios from 'vue-axios'
 
//Vue.use(VueAxios, axios)
export const  http = axios.create({
    baseURL: 'http://localhost:5000/api/'
})