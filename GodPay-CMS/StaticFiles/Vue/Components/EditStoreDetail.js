﻿import serverErrorMessage from './ServerErrorMessage.js'
export default {
    props: ['tempStore', 'modelStateError'],
    components: {
        serverErrorMessage
    },
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
        <p-dialog v-bind:header="'編輯特店資訊'" v-model:visible="displayModal" class="p-modal-sm p-modal-md p-modal-lg" v-bind:position="'top'" v-bind:modal="true">
            <v-form v-slot="{values, errors}" v-on:submit="SaveStore">
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row g-3 mb-5">
                            <div class="col-md-6">
                                <label for="StoreName" class="form-label">特店名稱</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="StoreName" v-model="storeModel.StoreName"
                                    name="StoreName" rules="required" v-bind:class="[{'is-invalid':errors['StoreName']||modelStateError['StoreName']}]" ></v-field>
                                <error-message name="StoreName" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'StoreName'"></server-error-message>
                            </div>
                            <div class="col-md-6">
                                <label for="TaxId" class="form-label">統一編號</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="TaxId" v-model="storeModel.TaxId"
                                    name="TaxId" rules="required" v-bind:class="[{'is-invalid':errors['TaxId']||modelStateError['TaxId']}]" ></v-field>
                                <error-message name="TaxId" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'TaxId'"></server-error-message>
                            </div>
                            <div class="col-md-6">
                                <label for="Owner" class="form-label">負責人</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="Owner" v-model="storeModel.Owner" name="Owner"></v-field>
                            </div>
                            <div class="col-md-6">
                                <label for="Address" class="form-label">公司地址</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="Address" v-model="storeModel.Address" name="Address"></v-field>
                            </div>
                            <div class="col-md-6">
                                <label for="OwnerEmail" class="form-label">負責人Email</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="OwnerEmail" v-model="storeModel.OwnerEmail"
                                    name="OwnerEmail" rules="required|email" v-bind:class="[{'is-invalid':errors['OwnerEmail']||modelStateError['OwnerEmail']}]"></v-field>
                                <error-message name="OwnerEmail" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'OwnerEmail'"></server-error-message>
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