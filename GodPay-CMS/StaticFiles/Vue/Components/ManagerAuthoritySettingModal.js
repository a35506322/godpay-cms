export default {
    components: {
        'pCard': primevue.card
    },
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
         <div class="modal-body" style="background-color: var(--surface-b);">
            <div class="container-fluid">
                <div class="row gy-5">
                    <div class="col-12 col-lg-6">
                        <p-card style="width: 25em" class="m-auto">
                            <template #title>
                                使用者帳號管理
                            </template>
                            <template #content>
                                <div class="row mb-3">
                                    <label class="col-sm-8 col-form-label pt-0">使用者帳號管理</label>
                                    <div class="col-sm-4">
                                        <div class="form-check">
                                            <input type="checkbox" class="p-checkbox p-component p-checkbox-checked form-check-input" style="margin-top:2px" value="1">
                                        </div> 
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label class="col-sm-8 col-form-label pt-0">編輯使用者資訊</label>
                                    <div class="col-sm-4">
                                        <div class="form-check">
                                            <input type="checkbox" class="p-checkbox p-component p-checkbox-checked form-check-input" style="margin-top:2px" value="2">
                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label class="col-sm-8 col-form-label pt-0">編輯使用者資訊</label>
                                    <div class="col-sm-4">
                                        <div class="form-check">
                                            <input type="checkbox" class="p-checkbox p-component p-checkbox-checked form-check-input" style="margin-top:2px" value="2">
                                        </div>
                                    </div>
                                </div>
                            </template>
                        </p-card>
                    </div>
                    <div class="col-12 col-lg-6">
                        <p-card style="width: 25em" class="m-auto">
                            <template #title>
                                使用者帳號管理
                            </template>
                            <template #content>
                                <div class="row mb-3">
                                    <label class="col-sm-8 col-form-label pt-0">使用者帳號管理</label>
                                    <div class="col-sm-4">
                                        <div class="form-check">
                                            <input type="checkbox" class="p-checkbox p-component p-checkbox-checked form-check-input" style="margin-top:2px" value="1">
                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label class="col-sm-8 col-form-label pt-0">編輯使用者資訊</label>
                                    <div class="col-sm-4">
                                        <div class="form-check">
                                            <input type="checkbox" class="p-checkbox p-component p-checkbox-checked form-check-input" style="margin-top:2px" value="2">
                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label class="col-sm-8 col-form-label pt-0">變更使用者密碼</label>
                                    <div class="col-sm-4">
                                        <div class="form-check">
                                            <input type="checkbox" class="p-checkbox p-component p-checkbox-checked form-check-input" style="margin-top:2px" value="4">
                                        </div>
                                    </div>
                                </div>
                            </template>
                        </p-card>
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