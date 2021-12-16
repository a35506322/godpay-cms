import serverErrorMessage from '/StaticFiles/Vue/Components/ServerErrorMessage.js'
export default {
    props: ['isNew', 'tempStore', 'modelStateError', 'tempAccountStatus'],
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
            this.displayModal = true;
        },
        Close: function () {
            this.displayModal = false;
        },
        SaveStore: function () {
            this.$emit('save', this.storeModel);
        }
    },
    watch: {
        tempStore: {
            handler: function (newVal, oldVal) {
                this.storeModel = { ...this.tempStore };
            },
            deep: true
        },
        isNew: function (newVal, oldVal) {
            if (newVal) {
                this.header = '新增業務資料'
            } else {
                this.header = '修改業務資料'
            }
        }
    },
    template:`
        <p-dialog v-bind:header="header" v-model:visible="displayModal" class="p-modal-sm p-modal-md p-modal-lg" v-bind:position="'top'" v-bind:modal="true">
            <v-form v-slot="{values, errors}" v-on:submit="SaveStore">
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
                                        v-model="storeModel.UserId" rules="required|account" name="UserId" v-bind:class="[{'is-invalid':errors['UserId']||modelStateError['UserId']}]" ></v-field>
                                    <error-message name="UserId" class="invalid-feedback"></error-message>
                                    <server-error-message v-bind:attr="'UserId'"></server-error-message>
                                </div>
                            </template>
                            <div class="col-md-6">
                                <label for="Email" class="form-label">Email</label>
                                <v-field type="email" class="p-inputtext p-component form-control" id="Email" v-model="storeModel.Email"
                                    name="Email" rules="required|email" v-bind:class="[{'is-invalid':errors['Email']||modelStateError['Email']}]" ></v-field>
                                <error-message name="Email" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'Email'"></server-error-message>
                            </div>
                            <template v-if="!isNew">
                                <div class="col-md-6">
                                    <label for="Status" class="form-label">帳號狀態</label>
                                    <v-field id="Status" class="form-select rounded-1" v-model="storeModel.Status" as="select" name="Status" rules="required" v-bind:class="[{'is-invalid':errors['Status']||modelStateError['Status']}]" >
                                        <option v-for="(status,index) in tempAccountStatus" v-bind:key="status.key" v-bind:value="status.value">{{status.key}}</option>
                                    </v-field>
                                    <error-message name="Status" class="invalid-feedback"></error-message>
                                    <server-error-message v-bind:attr="'Status'"></server-error-message>
                                </div>
                            </template>
                        </div>
                        <div class="row g-3 mb-5">
                            <div class="d-flex justify-content-center p-0">
                                <h5 class="w-98 fs-4 fw-bold border-bottom border-2 border-gray py-1">詳細資料</h5>
                            </div>
                            <div class="col-md-6">
                                <label for="Name" class="form-label">特店名稱</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="StoreName" v-model="storeModel.StoreName"
                                    name="FullName" rules="required" v-bind:class="[{'is-invalid':errors['StoreName']||modelStateError['StoreName']}]" ></v-field>
                                <error-message name="StoreName" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'StoreName'"></server-error-message>
                            </div>
                            <div class="col-md-6">
                                <label for="Department" class="form-label">統一編號</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="TaxId" v-model="storeModel.TaxId"
                                    name="ShortName" rules="required" v-bind:class="[{'is-invalid':errors['TaxId']||modelStateError['TaxId']}]" ></v-field>
                                <error-message name="TaxId" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'TaxId'"></server-error-message>
                            </div>
                            <div class="col-md-6">
                                <label for="Name" class="form-label">負責人</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="Owner" v-model="storeModel.Owner"
                                    name="Owner" ></v-field>
                            </div>
                            <div class="col-md-6">
                                <label for="Name" class="form-label">公司地址</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="Address" v-model="storeModel.Address"
                                    name="Address" ></v-field>
                            </div>
                            <div class="col-md-6">
                                <label for="Name" class="form-label">負責人Email</label>
                                <v-field type="text" class="p-inputtext p-component form-control" id="OwnerEmail" v-model="storeModel.OwnerEmail"
                                    name="OwnerEmail" ></v-field>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="p-dialog-footer">
                    <p-button label="取消" icon="pi pi-times" v-on:click="Close()" class="p-button-text"></p-button>
                    <p-button label="儲存" icon="pi pi-check" autofocus type="submit"></p-button>
                </div>
                <v-form>          
        </p-dialog>`
}