import serverErrorMessage from './ServerErrorMessage.js'
export default {
    props: ['isNew', 'tempStorePersonnel', 'modelStateError', 'tempAccountStatus', "tempCustomers","tempLoginId"],
    components: {
        serverErrorMessage
    },
    data: function () {
        return {
            displayModal: false,
            storePersonnelModel: {},
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
        SaveStorePersonnel: function () {
            this.$emit('save', this.storePersonnelModel);
        }
    },
    watch: {
        tempStorePersonnel: {
            handler: function (newVal, oldVal) {
                this.storePersonnelModel = { ...this.tempStorePersonnel };
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
        <p-dialog v-bind:header="header" v-model:visible="displayModal" class="p-modal p-modal-lg" v-bind:position="'top'" v-bind:modal="true">
            <v-form v-slot="{values, errors}" v-on:submit="SaveStorePersonnel">
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row g-3 mb-5">
                            <div class="d-flex justify-content-center p-0">
                                <h5 class="w-98 fs-4 fw-bold border-bottom border-2 border-gray py-1">帳號資訊</h5>
                            </div>
                            <template v-if="isNew">
                                <div class="col-md-6">
                                    <label for="userId" class="form-label">帳號</label>
                                    <div class="p-inputgroup flex-wrap">
                                        <span class="p-inputgroup-addon">
                                            {{tempLoginId}}
                                        </span>
                                        <v-field type="text" class="p-inputtext p-component form-control" id="userId"
                                            v-model="storePersonnelModel.userId" rules="required|account" name="帳號" v-bind:class="[{'is-invalid':errors['帳號']||modelStateError['userId']}]" ></v-field>
                                        <error-message name="帳號" class="invalid-feedback"></error-message>
                                        <server-error-message v-bind:attr="'userId'"></server-error-message>
                                    </div>                    
                                </div>
                            </template>
                            <div class="col-md-6">
                                <label for="email" class="form-label">Email</label>
                                <v-field type="email" class="p-inputtext p-component form-control" id="email" v-model="storePersonnelModel.email"
                                    name="email" rules="required|email" v-bind:class="[{'is-invalid':errors['email']||modelStateError['email']}]" ></v-field>
                                <error-message name="email" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'email'"></server-error-message>
                            </div>
                            <template v-if="!isNew">
                                <div class="col-md-6">
                                    <label for="status" class="form-label">帳號狀態</label>
                                    <v-field id="Status" class="form-select rounded-1" v-model="storePersonnelModel.status" as="select" name="帳號狀態" rules="required" v-bind:class="[{'is-invalid':errors['帳號狀態']||modelStateError['status']}]" >
                                        <option v-for="(status,index) in tempAccountStatus" v-bind:key="status.key" v-bind:value="status.value">{{status.key}}</option>
                                    </v-field>
                                    <error-message name="帳號狀態" class="invalid-feedback"></error-message>
                                    <server-error-message v-bind:attr="'status'"></server-error-message>
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