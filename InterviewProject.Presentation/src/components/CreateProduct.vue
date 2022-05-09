<template>
  <div class="col-md-12">
    <div class="card card-container">
      <form name="form" @submit.prevent="handleCreateProduct">
        <div v-if="!successful">
          <div class="form-group">
            <label for="productName">Product Name</label>
            <input
              v-model="product.productName"
              type="text"
              class="form-control"
              name="productName"
            />
          </div>
          <div class="form-group">
            <label for="description">Description</label>
            <textarea
              rows="2"
              v-model="product.description"
              class="form-control"
              name="description"
            ></textarea>
          </div>
          <div class="form-group">
            <label for="categoryId">Category</label>
            <select class="form-control" v-model="product.categoryId">
              <option disabled value="">Please select one</option>
              <option v-for="ctg in this.Categories" :key="ctg.id" :value="ctg.id">{{ctg.CategoryName}}</option>
            </select>
          </div>
          <div class="form-group">
            <label for="UnitOfMeasureId">Unit Of Measurement</label>
            <select  class="form-control" v-model="product.unitOfMeasureId">
              <option disabled value="">Please select one</option>
              <option v-for="unit in this.UOM" :key="unit.id" :value="unit.id">{{unit.UnitName}}</option>
            </select>
          </div>
          <div class="form-group">
            <label for="PricePerUnit">Price Per Unit</label>
            <input
              v-model="product.pricePerUnit"
              type="number"
              step="any"
              class="form-control"
              name="PricePerUnit"
            />
            <div>
             </div>
          </div>
          <div class="form-group">
            <label for="Image">Product Images</label>
            <input @change="uploadImage($event)" type="file" multiple="multiple" accept="image/*" name="photo" />
            <div v-if="fileSrcs">
              <div v-for="(uploadedImage,i) in fileSrcs" :key="i">
                <img class="image-container" :src="uploadedImage">  
              </div>
            </div>
          </div>
          <div class="form-group mt-2">
                <button class="btn btn-primary btn-block">Create</button>
                <button class="btn btn-secondary btn-block ms-2" @click="backToHome()">Cancel</button>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import { mapActions } from 'vuex'
export default {
    name: "CreateProduct",
    data(){
      return {
          product: {},
          submitted: false,
          successful: false,
          message: "",
          fileSrcs: [],
          UOM: [
            {
              id:1,
              UnitName:"Box"
            },
            {
              id:2,
              UnitName:"Kilo"
            },
            {
              id:3,
              UnitName:"Bar"
            },
            {
              id:4,
              UnitName:"Bag"
            },
          ],
          Categories: [
            {
              id:1,
              CategoryName:"Candy"
            },
            {
              id:2,
              CategoryName:"Cake"
            }
          ]
      }
    },
    methods: {
      ...mapActions("productModule", { createProduct: "createProduct" }),

      handleCreateProduct() {
          var payload = {
              productName: this.product.productName,
              description: this.product.description,
              categoryId: this.product.categoryId,
              unitOfMeasureId: this.product.unitOfMeasureId,
              pricePerUnit: this.product.pricePerUnit,
              imageFiles: this.product.files
          }
          
          this.createProduct(payload).then((result) => {
              if (result) {
                  this.$router.push("/Home")
              }
          })
      },

      uploadImage(e) {
        this.product.files = e.target.files
        for(let i = 0; i < this.product.files.length; i++) {
          this.fileSrcs.push(window.URL.createObjectURL(this.product.files[i]))
        }
      },

      backToHome() {
        this.$router.push("/Home")
      }
    }
}
</script>

<style scoped>
.image-container {
  width:50%;
  height:50%;
}

label {
  display: block;
  margin-top: 10px;
}

.card-container.card {
  max-width: 800px !important;
  padding: 40px 40px;
}

.card {
  background-color: #f7f7f7;
  padding: 20px 25px 30px;
  margin: 0 auto 25px;
  margin-top: 50px;
  border-radius: 2px;
}

</style>  