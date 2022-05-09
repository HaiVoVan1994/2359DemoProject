<template>
  <div class="mt-5">
    <div class="row">
      <div class="col-sm-12">
        <form name="form" @submit.prevent="searchProductHandle" class="d-flex">
          <div class="col-sm-3">
            <label for="gender">Product Name</label>
            <input class="form-control" type='text' v-model="search.productName" placeholder='Product Name'/>
          </div>
           <div class="col-sm-3 ms-2">
          <label for="gender">Product Category</label>
          <select class="form-control" v-model="search.categoryId">
            <option value="">All</option>
            <option v-for="ctg in Categories" :key="ctg.id" :value="ctg.id">{{ctg.CategoryName}}</option>
          </select>
           </div>
           <div class="col-sm-3 ms-2">
          <label for="gender">Product Status</label>
          <select class="form-control" v-model="search.productStatusId1">
            <option value="">All</option>
            <option v-for="status in productStatus" :key="status.id" :value="status.id">{{status.description}}</option>
          </select>
           </div>
           <div class="col-sm-3 search-btn-area ms-2">
            <button class="btn btn-primary">Search</button>
            <button v-if="this.getUserRole === 'Admin'" class="btn btn-success ms-2" @click="showCreateProductPage()">Create</button>
           </div>
        </form>
      </div>
    </div>
    <div class="row">
      <div v-for="product in getProducts.products" :key="product.id" class="col-sm-4 card">
        <div class="mb-2">
          <img :src="'data:image/png;base64,'+ product.images[0].imageBase64" class="image-container" />
        </div>
        <div>
          <h4 class="product-name" @click="showProductDetail(product)">{{ product.productName }}</h4>
          <p>{{ product.description }}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

import { mapActions, mapGetters } from "vuex"

export default {
  name: 'Home',
  components: {
  },
  data() {
    return {
      search: {},
      Categories: [
            {
              id:1,
              CategoryName:"Candy"
            },
            {
              id:2,
              CategoryName:"Cake"
            }
          ],
      productStatus: [
        {
          id: 0,
          description: "Unavailable"
        }, 
        {
          id: 1,
          description: "Available"
        }
      ]
    };
  },
  created() {
      this.searchProduct({ ProductName : "", CategoryId: -1, ProductStatus: -1 })
  },
  computed: {
     ...mapGetters({
        getProducts: 'productModule/getProducts',
        getUserRole: 'authModule/getUserRole',
     })
  },
  methods: {
    ...mapActions("productModule", { searchProduct: "searchProduct", selectedProduct: "setSelectedProduct" }),

    searchProductHandle() {
        const query = {
            ProductName:  this.search.productName != "" && this.search.productName != undefined ? this.search.productName : "",
            CategoryId: this.search.categoryId ? this.search.categoryId : -1,
            ProductStatus: this.search.productStatusId ? this.search.productStatusId : -1
        }
        this.searchProduct(query)
    },

    showProductDetail(selectedProduct) {
        this.selectedProduct(selectedProduct)
        this.$router.push("/ProductDetail")
    },

    showCreateProductPage() {
        this.$router.push("/CreateProduct")
    } 
  }
};
</script>

<style scoped>
.product-name {
  cursor: pointer;
}

.image-container {
  width: 100%;
  height: auto;
}

.search-btn-area {
  margin-top: 33px;
}

label {
  display: block;
  margin-top: 10px;
}

.card-container.card {
  max-width: 350px !important;
  padding: 40px 40px;
}

.card {
  background-color: #f7f7f7;
  padding: 20px 25px 30px;
  margin: 0 auto 25px;
  margin-top: 50px;
  border-radius: 2px;
}

.profile-img-card {
  width: 96px;
  height: 96px;
  margin: 0 auto 10px;
  display: block;
  border-radius: 50%;
}
</style>
