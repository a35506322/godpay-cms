export default {
    props: ['tempStore', 'modelStateError'],
    data: function () {
        return {
            displayModal: false,
            storeModel: {},
            header: ''
        }
    },
    methods: {
        Show: function () {
            this.storeModel = { ...this.tempStore };
            this.displayModal = true;
        },
        Close: function () {
            this.displayModal = false;
        },
        SaveStore: function () {
            this.$emit('save', this.storeModel);
        }
    },
    template: `
        <p-dialog v-bind:header="'編輯特店資訊'" v-model:visible="displayModal" class="p-modal p-modal-lg p-modal-x1 p-modal-xx1" v-bind:position="'top'" v-bind:modal="true">
            <v-form v-slot="{values, errors}" v-on:submit="SaveStore">
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row g-3 mb-5">
                            <div class="col-md-6">
                                <label for="storeName" class="form-label">特店名稱</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="storeName" v-model.trim ="storeModel.storeName"
                                    name="特店名稱" rules="required" v-bind:class="[{'is-invalid':errors['特店名稱']||modelStateError['storeName']}]" ></v-field>
                                <error-message name="特店名稱" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'storeName'"></server-error-message>
                            </div>
                            <div class="col-md-6">
                                <label for="taxId" class="form-label">統一編號</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="taxId" v-model.number ="storeModel.taxId"
                                    name="統一編號" rules="required" v-bind:class="[{'is-invalid':errors['統一編號']||modelStateError['taxId']}]" ></v-field>
                                <error-message name="統一編號" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'taxId'"></server-error-message>
                            </div>
                            <div class="col-md-6">
                                <label for="owner" class="form-label">負責人</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="owner" v-model.trim ="storeModel.owner" name="負責人"
                                    rules="required" v-bind:class="[{'is-invalid':errors['負責人']||modelStateError['owner']}]"></v-field>
                                <error-message name="負責人" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'owner'"></server-error-message>
                            </div>
                            <div class="col-md-6">
                                <label for="address" class="form-label">公司地址</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="address" v-model.trim ="storeModel.address" name="公司地址"
                                    rules="required" v-bind:class="[{'is-invalid':errors['公司地址']||modelStateError['address']}]"></v-field>
                                <error-message name="公司地址" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'address'"></server-error-message>
                            </div>
                            <div class="col-md-6">
                                <label for="ownerEmail" class="form-label">負責人Email</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="ownerEmail" v-model.trim ="storeModel.ownerEmail"
                                    name="負責人Email" rules="required|email" v-bind:class="[{'is-invalid':errors['負責人Email']||modelStateError['ownerEmail']}]"></v-field>
                                <error-message name="負責人Email" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'ownerEmail'"></server-error-message>
                            </div>
                            <div class="col-md-6">
                                <label for="receivingBankCode" class="form-label">收款銀行代碼</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="receivingBankCode" v-model.trim="storeModel.receivingBankCode"
                                    name="收款銀行代碼" rules="required|onlyNumber" v-bind:class="[{'is-invalid':errors['收款銀行代碼']||modelStateError['receivingBankCode']}]"></v-field>
                                <error-message name="收款銀行代碼" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'receivingBankCode'"></server-error-message>
                            </div>
                            <div class="col-md-6">
                                <label for="receivingBranch" class="form-label">收款銀行分行</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="receivingBranch" v-model.trim="storeModel.receivingBranch"
                                    name="收款分行" rules="required|onlyNumber" v-bind:class="[{'is-invalid':errors['收款分行']||modelStateError['receivingBranch']}]"></v-field>
                                <error-message name="收款分行" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'receivingBranch'"></server-error-message>
                            </div>
                            <div class="col-md-6">
                                <label for="receivingAccount" class="form-label">收款銀行帳號</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="receivingAccount" v-model.trim="storeModel.receivingAccount"
                                    name="收款帳號" rules="required|onlyNumber" v-bind:class="[{'is-invalid':errors['收款帳號']||modelStateError['receivingAccount']}]"></v-field>
                                <error-message name="收款帳號" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'receivingAccount'"></server-error-message>
                            </div>
                            <div class="col-md-6">
                                <label for="moneyTransferDay" class="form-label">匯款天數</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="moneyTransferDay" v-model.number="storeModel.moneyTransferDay"
                                    name="匯款天數" rules="required|min_value:1|max_value:30" v-bind:class="[{'is-invalid':errors['匯款天數']||modelStateError['moneyTransferDay']}]"></v-field>
                                <error-message name="匯款天數" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'moneyTransferDay'"></server-error-message>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="p-dialog-footer">
                    <p-button label="取消" icon="pi pi-times" v-on:click="Close()" class="p-button-text"></p-button>
                    <p-button label="儲存" icon="pi pi-check" autofocus type="submit"></p-button>
                </div>
                </v-form>          
        </p-dialog>`
}