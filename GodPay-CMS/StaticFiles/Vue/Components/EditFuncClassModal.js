export default {
    props: ['isNew', 'funcClass', 'modelStateError', 'tempLoading'],
    data: function () {
        return {
            displayModal: false,
            classModel: {},
            header: ''
        }
    },
    methods: {
        Show: function (isNew) {
            if (isNew) {
                this.header = '新增類別'
            } else {
                this.header = '修改類別'
            }
            this.displayModal = true;
        },
        Close: function () {
            this.displayModal = false;
        },
        SaveClass: function () {
            this.$emit('save', this.classModel);
        }
    },
    watch: {
        funcClass: {
            handler: function (newVal, oldVal) {
                this.classModel = { ...this.funcClass };
            },
            deep: true
        }
    },
    template:`
        <p-dialog v-bind:header="header" v-model:visible="displayModal" class="p-modal p-modal-lg p-modal-x1 p-modal-xx1" v-bind:position="'top'" v-bind:modal="true">
            <v-form v-slot="{values, errors}" v-on:submit="SaveClass">
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row g-3 mb-5">
                            <div class="col-md-6">
                                <label for="funcClassEnName" class="form-label">類別英文名稱</label>
                                <v-field class="p-inputtext p-component form-control" id="funcClassEnName"
                                    v-model.trim="classModel.funcClassEnName" name="類別英文名稱" rules="required|enClass" v-bind:class="[{'is-invalid':errors['類別英文名稱']||modelStateError['funcClassEnName']}]"
                                />
                                <error-message name="類別英文名稱" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'funcClassEnName'"></server-error-message>
                            </div>
                            <div class="col-md-6">
                                <label for="funcClassChName" class="form-label">類別中文名稱</label>
                                <v-field class="p-inputtext p-component form-control" id="funcClassChName"
                                    v-model.trim="classModel.funcClassChName" name="類別中文名稱" rules="required|chClass" v-bind:class="[{'is-invalid':errors['類別中文名稱']||modelStateError['funcClassChName']}]"
                                />
                                <error-message name="類別中文名稱" class="invalid-feedback"></error-message>
                                <server-error-message v-bind:attr="'funcClassChName'"></server-error-message>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="p-dialog-footer">
                    <p-button label="取消" icon="pi pi-times" v-on:click="Close()" class="p-button-text"></p-button>
                    <p-button label="儲存" icon="pi pi-check" autofocus type="submit" v-bind:loading="tempLoading"></p-button>
                </div>
                </v-form>
    </p-dialog>`
}