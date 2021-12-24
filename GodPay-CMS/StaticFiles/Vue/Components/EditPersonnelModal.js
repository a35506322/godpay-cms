import serverErrorMessage from './ServerErrorMessage.js'
export default {
    props: ['isNew', 'tempStore', 'modelStateError', 'tempAccountStatus', "tempCustomers"],
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
                this.header = '新增特店人員'
            } else {
                this.header = '修改特店人員'
            }
        }
    },
    template: `
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
                                    <div class="p-inputgroup">
                                        <span class="p-inputgroup-addon">s22s22</span>
                                        <v-field type="text" class="p-inputtext p-component form-control" id="UserId"
                                            v-model="storeModel.UserId" rules="required|account" name="UserId" v-bind:class="[{'is-invalid':errors['UserId']||modelStateError['UserId']}]" ></v-field>
                                    </div>
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
                    </div>
                </div>
                <div class="p-dialog-footer">
                    <p-button label="取消" icon="pi pi-times" v-on:click="Close()" class="p-button-text"></p-button>
                    <p-button label="儲存" icon="pi pi-check" autofocus type="submit"></p-button>
                </div>
                </v-form>          
        </p-dialog>`
}