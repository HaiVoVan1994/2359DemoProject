import axios from "axios";
import { API_URL_PRODUCT } from "../Utility/constant";

const state = () => ({
    products: [],
    selectedProduct: {}
});

const getters = {
    getProducts(state) {
        return state.products
    },
    getSelectedProduct(state) {
        return state.selectedProduct
    },
};

const actions = {
    searchProduct({ commit }, payload) {
        return new Promise ((resolve, reject) => {
            const query = `ProductName=${payload.ProductName}&CategoryId=${payload.CategoryId}&ProductStatus=${payload.ProductStatus}`
            axios.get(API_URL_PRODUCT + `/SearchProduct?${query}`).then(response => {
            if (response && response.data) {
                commit("setProductData", response.data.payload)
            }
            resolve()
            }).catch(e => {
            console.log(e)
            reject()
            })
        })
    },

    setSelectedProduct({commit}, payload) {
        commit("setSelectedProduct", payload)
    },

    createProduct(_, payload) {
        let formData = new FormData();
        
        if(payload.imageFiles.length > 0) {
            for(var i = 0; i < payload.imageFiles.length; i++) {
                formData.append('files', payload.imageFiles.item(i));    
            }
        } 

        for(var key in payload) {
            formData.append(key, payload[key])
        }

        return new Promise ((resolve, reject) => {
            axios.post(API_URL_PRODUCT + `/CreateProduct`, formData).then(() => {
            resolve(true)
            }).catch(e => {
            console.log(e)
            reject(false)
            })
        })
    },
};

const mutations = {
    setProductData(state, payload) {
        state.products = payload
    },
    
    setSelectedProduct(state, payload) {
        state.selectedProduct = payload;
    }
};

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,
};
