export default {
    props: ['isNew', 'func', 'modelStateError', 'funcClassList', 'tempLoading'],
    components: {
        "p-checkbox": primevue.checkbox
    },
    data: function () {
        return {
            displayModal: false,
            funcModel: {},
            header: '',
            funcList: [],
        }
    },
    methods: {
        Show: function (isNew) {
            if (isNew) {
                this.header = '新增功能'
            } else {
                this.header = '修改功能'
            }
            this.displayModal = true;
        },
        Close: function () {
            this.displayModal = false;
        },
        SaveFunc: function () {
            this.$emit('save', this.funcModel);
        }
    },
    watch: {
        func: {
            handler: function (newVal, oldVal) {
                this.funcModel = { ...this.func };
            },
            deep: true
        },
        funcClassList: {
            handler: function (newVal, oldVal) {
                for (let i = 0; i < this.funcClassList.length; i++) {
                    this.funcList.push(this.funcClassList[i]);
                }
            },
            deep: true
        }
    },
    template:`
        <p-dialog v-bind:header="header" v-model:visible="displayModal" class="p-modal p-modal-lg p-modal-x1 p-modal-xx1" v-bind:position="'top'" v-bind:modal="true">
            <v-form v-slot="{values, errors}" v-on:submit="SaveFunc">
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row g-3 mb-5">
                            <div class="col-md-6">
                                <label for="Email" class="form-label">功能類別</label>
                                <v-field id="funcClassCode" class="form-select rounded-1" v-model="funcModel.funcClassCode" as="select" name="功能類別" rules="required"
                                        v-bind:class="[{'is-invalid':errors['功能類別']||modelStateError['funcClassCode']}]" >
                                        <option v-for="(func,index) in funcList" v-bind:key="func.funcClassCode" v-bind:value="func.funcClassCode">{{func.funcClassChName}}</option>
                                </v-field>
                                <error-message name="功能類別" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'funcClassCode'"></server-error-message>      
                            </div>
                            <div class="col-md-6">
                                <label for="isWebSite" class="form-label">網頁是否顯示</label>
                                <p-checkbox class="d-block" v-model="funcModel.isWebSite" v-bind:binary="true" />
                            </div>
                        </div>
                        <div class="row g-3 mb-5">
                            <div class="col-md-6">
                                <label for="Email" class="form-label">功能英文名稱</label>
                                <v-field class="p-inputtext p-component form-control"
                                    v-model="funcModel.funcEnName" name="功能英文名稱" rules="required|enClass" v-bind:class="[{'is-invalid':errors['功能英文名稱']||modelStateError['funcEnName']}]"
                                />
                                <error-message name="功能英文名稱" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'funcEnName'"></server-error-message>
                            </div>
                            <div class="col-md-6">
                                <label for="Status" class="form-label">功能中文名稱</label>
                                <v-field class="p-inputtext p-component form-control"
                                    v-model="funcModel.funcChName" name="功能中文名稱" rules="required|chClass" v-bind:class="[{'is-invalid':errors['功能中文名稱']||modelStateError['funcChName']}]"
                                />
                                <error-message name="功能中文名稱" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'funcChName'"></server-error-message>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="p-dialog-footer">
                    <p-button label="取消" icon="pi pi-times" v-on:click="Close()" class="p-button-text"></p-button>
                    <p-button label="儲存" icon="pi pi-check" autofocus type="submit" v-bind:loading="tempLoading"></p-button>
                </div>
            </v-form>
        </p-dialog > `
}