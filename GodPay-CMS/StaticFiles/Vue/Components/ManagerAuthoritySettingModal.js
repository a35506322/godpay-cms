export default {
    data: function () {
        return {
            displayModal: false,
        }
    },
    methods: {
        Show: function () {
            this.displayModal = true;
        },
        Close: function () {
            this.displayModal = false;
        }
    },
    template: `
    <p-dialog header="業務權限設定" v-model:visible="displayModal" class="p-modal p-modal-lg" v-bind:position="'top'" v-bind:modal="true">
         <div class="modal-body">
            <div class="container-fluid">
              
            </div>
         </div>
    </p-dialog>`
}