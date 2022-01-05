export default {
    props: ['storeAuthority', 'tempUid'],
    components: {
        'pCard': primevue.card
    },
    data: function () {
        return {
            displayModal: false,
            tempModel: {},
            updateUserAuthorityViewModel: {}
        }
    },
    methods: {
        Show: function () {
            this.updateUserAuthorityViewModel = {}
            this.displayModal = true;
        },
        Close: function () {
            this.displayModal = false;
        },
        changeJson: function (obj) {
            return JSON.parse(JSON.stringify(obj))
        },
        SaveAuthority: function () {
            var total = 0;
            this.tempModel.forEach(element => {
                console.log(element);
                element.userAuthorityFuncRsps.forEach(elem => {
                    if (elem.isAuthority === true) {
                        total += elem.funcCode;
                    }
                });
            });
            this.updateUserAuthorityViewModel = {
                uid: this.tempUid,
                func: total,
            }
            this.$emit('save', this.updateUserAuthorityViewModel)
        }
    },
    watch: {
        storeAuthority: {
            handler: function (newVal, oldVal) {
                this.tempModel = this.changeJson(this.storeAuthority);
            },
            deep: true
        }
    },
    template: `
    <p-dialog header="特店權限設定" v-model:visible="displayModal" class="p-modal p-modal-lg p-modal-x1 p-modal-xx1" v-bind:position="'top'" v-bind:modal="true">
        <v-form v-slot="{values, errors}" v-on:submit ="SaveAuthority">
         <div class="modal-body" style="background-color: var(--surface-b);">
            <div class="container-fluid">
                <div class="row gy-5">
                <template v-for="(authority,index) in tempModel"  v-bind:key="authority.funcClassCode">
                    <div class="col-12 col-lg-6">
                        <p-card class="m-auto p-card-width p-card-width-lg p-card-width-xxl">
                            <template #title>
                                {{authority.funcClassChName}}
                            </template>
                            <template #content>
                            <template v-for="(func,index) in authority.userAuthorityFuncRsps" v-bind:key="func.funcCode">
                                <div class="row mb-3">
                                    <label class="col-sm-8 col-form-label pt-0">{{func.funcChName}}</label>
                                    <div class="col-sm-4">
                                        <div class="form-check">
                                            <input type="checkbox" class="p-checkbox p-component p-checkbox-checked form-check-input" style="margin-top:2px" v-model="func.isAuthority">
                                        </div> 
                                    </div>
                                </div>
                            </template>
                            </template>
                        </p-card>
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