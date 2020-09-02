const state = {
    usuarioLogadoId: null,
};
const getters = {
    isUsuarioLogado: (state) => {
        if (state.usuarioLogadoId != null) {
            return true
        }
        return false
    }
};
const mutations = {
    setUsuarioLogadoId(state, {
        id
    }) {
        state.usuarioLogadoId = id;
    },
    deleteUsuarioLogadoId(state) {
        state.usuarioLogadoId = null;
        //console.log(state.usuarioLogadoId )
    },
    ///////////////////////////
    // createUsuario(state, {
    //     usuario
    // }) {
    //     let idHolder = 0;
    //     for (let e of state.usuarios) {
    //         if (idHolder < e.id) {
    //             idHolder = e.id;
    //         }
    //     }
    //     usuario.id = ++idHolder;
    //     state.usuarios.push(usuario);
    // }
};
const actions = {
    login({
        commit
    }, id) {
        commit('setUsuarioLogadoId', {
            id
        })
    },
    logout({
        commit
    }) {
        commit('deleteUsuarioLogadoId')
    },
    // ////////////////////////////
    // createUsuario({
    //     commit
    // }, usuario) {
    //     commit('createUsuario', {
    //         usuario
    //     })
    // }
};

export default {
    state,
    getters,
    actions,
    mutations,
};