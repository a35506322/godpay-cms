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
    <p-dialog v-bind:header="'新增類別'" v-model:visible="displayModal"  class="p-modal p-modal-lg" v-bind:position="'top'" v-bind:modal="true">
             <div class="modal-body">
                <div class="container-fluid">               
                        <div class="row g-3 mb-5">
                            <div class="col-md-6">
                                <label for="Email" class="form-label">類別英文名稱</label>
                                <input class="p-inputtext p-component form-control" />
                            </div>
                            <div class="col-md-6">
                                <label for="Status" class="form-label">類別中文名稱</label>
                                <input class="p-inputtext p-component form-control" />
                            </div>
                        </div>
                    </div>
             </div>
            <div class="p-dialog-footer">
                <p-button label="取消" icon="pi pi-times" v-on:click="Close()" class="p-button-text"></p-button>
                <p-button label="儲存" icon="pi pi-check" autofocus type="submit"></p-button>
            </div>
    </p-dialog>`
}