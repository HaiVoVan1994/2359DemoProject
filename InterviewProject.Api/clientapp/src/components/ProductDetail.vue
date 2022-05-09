<template>
    <div class="container">
      <div class="row">
        <div class="col-md-6">
         <carousel-3d>
            <slide v-for="(image, i) in this.selectedProduct.images" :index="i" :key="i">
                <template slot-scope="{ index, isCurrent, leftIndex, rightIndex }">
                    <img :data-index="index" :class="{ current: isCurrent, onLeft: (leftIndex >= 0), onRight: (rightIndex >= 0) }" :src="'data:image/png;base64,'+ image.imageBase64">
                </template>
            </slide>
        </carousel-3d>
        </div>
        <div class="col-md-4 product-info-detail">
            <h1 class="my-4">{{ this.selectedProduct.productName }} - {{ this.selectedProduct.pricePerUnit }}$</h1>
            <div>
            <label>Description: <b>{{ this.selectedProduct.description }}</b></label> 
            </div>
            <div>
            <label>Category: <b>{{ this.selectedProduct.categoryName }}</b></label> 
            </div>
            <div>
            <label>UOM: <b>{{ this.selectedProduct.unitOfMeasureName }}</b></label> 
            </div>
            <div>
            <label>Status: <b>{{ this.selectedProduct.statusDescription }}</b></label> 
            </div>
            <button type="button" class="btn btn-primary btn-block btn-custom-color" @click="addToCart">
                Add To Cart
            </button>   
            <button type="button" class="btn btn-secondary btn-block btn-custom-color ms-2" @click="backToHome">
                Back To Home
            </button> 
        </div>
      </div>
    </div>
</template>

<script>
import { Carousel3d, Slide } from "vue-carousel-3d"
import { mapState } from "vuex"

export default {
    components: {
        Carousel3d,
        Slide
    },
    computed: {
        ...mapState({ selectedProduct : state => state.productModule.selectedProduct})
    },
    methods: {
        addToCart() {
            alert("This feature will be implemented later")
        },

        backToHome() {
            this.$router.push("/Home")
        }
    }
}   
</script>

<style>
.product-info-detail {
    line-height: 50px;
}
</style>