import serverErrorMessage from '/StaticFiles/Vue/Components/ServerErrorMessage.js'
import {  } from '/StaticFiles/Vue/Services/IpassService.js'
export default {
    props: ['isNew', 'tempBusinesse', 'modelStateError','tempAccountStatus'],
    components: {
        serverErrorMessage
    },
    data: function () {
        return {
            displayModal: false,
            tempModel: {},
            header: ''
        }
    },
    methods: {
        Show: function () {
            if (this.isNew) {
                this.header = '新增業務資料'
            } else {
                this.header = '修改業務資料'
            }
            this.displayModal = true;
        },
        Close: function () {
            this.displayModal = false;
        },
        SaveBusinessman: function () {
            this.$emit('save', this.tempModel);
        }
    },
    watch: {
        tempBusinesse: {
            handler: function (newVal, oldVal) {
                this.tempModel = { ...this.tempBusinesse };
                if (this.isNew) {
                    this.tempModel.Status = 11;
                }
            },
            deep: true
        }
    },
    template: `
    <p-dialog v-bind:header="header" v-model:visible="displayModal"  class="p-modal p-modal-lg" v-bind:position="'top'" v-bind:modal="true">
        <v-form v-slot="{values, errors}"  v-on:submit="SaveBusinessman">
             <div class="modal-body">
                <div class="container-fluid">               
                        <div class="row g-3 mb-5">
                            <div class="d-flex justify-content-center p-0">
                                <h5 class="w-98 fs-4 fw-bold border-bottom border-2 border-gray py-1">帳號資訊</h5>
                            </div>
                            <template v-if="isNew">
                                <div class="col-md-6">
                                    <label for="UserId" class="form-label">帳號</label>
                                    <v-field type="text" class="p-inputtext p-component form-control" id="UserId"
                                     v-model="tempModel.UserId" rules="required|account" name="UserId" v-bind:class="[{'is-invalid':errors['UserId']||modelStateError['UserId']}]"></v-field>
                                    <error-message name="UserId" class="invalid-feedback"></error-message>
                                    <server-error-message v-bind:attr="'UserId'"></server-error-message>
                                </div>
                            </template>
                            <div class="col-md-6">
                                <label for="Email" class="form-label">Email</label>
                                <v-field type="email" class="p-inputtext p-component form-control" id="Email" v-model="tempModel.Email"
                                rules="required|email" name="Email" v-bind:class="[{'is-invalid':errors['Email']||modelStateError['Email']}]"></v-field>
                                <error-message name="Email" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'Email'"></server-error-message>
                            </div>
                            <div class="col-md-6">
                                <label for="Status" class="form-label">帳號狀態</label>
                                <v-field id="Status" class="form-select rounded-1" v-model="tempModel.Status" as="select"
                                    rules="required" name="Status" v-bind:class="[{'is-invalid':errors['Status']||modelStateError['Status']}]">
                                    <option v-for="(status,index) in tempAccountStatus" v-bind:key="status.key" v-bind:value="status.value">{{status.key}}</option>
                                </v-field>
                                <error-message name="Status" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'Status'"></server-error-message>
                            </div>
                        </div>
                        <div class="row g-3 mb-5">
                            <div class="d-flex justify-content-center p-0">
                                <h5 class="w-98 fs-4 fw-bold border-bottom border-2 border-gray py-1">詳細資料</h5>
                            </div>
                            <div class="col-md-6">
                                <label for="Name" class="form-label">名子</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="Name" v-model="tempModel.Name"
                                rules="required" name="Name" v-bind:class="[{'is-invalid':errors['Name']||modelStateError['Name']}]"></v-field>
                                <error-message name="Name" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'Name'"></server-error-message>
                            </div>                           
                            <div class="col-md-6">
                                <label for="Department" class="form-label">部門</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="Department" v-model="tempModel.Department"
                                rules="required" name="Department" v-bind:class="[{'is-invalid':errors['Department']||modelStateError['Department']}]"></v-field>
                                <error-message name="Department" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'Department'"></server-error-message>
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