export default {
    props: ['managerAuthority'],
    components: {
        'pCard': primevue.card
    },
    data: function () {
        return {
            displayModal: false,
            tempModel: {}
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
    watch: {
        managerAuthority: {
            handler: function (newVal, oldVal) {
                this.tempModel = { ...this.managerAuthority };
            },
            deep: true
        }
    },
    template: `
    <p-dialog header="業務權限設定" v-model:visible="displayModal" class="p-modal p-modal-lg" v-bind:position="'top'" v-bind:modal="true">
         <div class="modal-body" style="background-color: var(--surface-b);">
            <div class="container-fluid">
                <div class="row gy-5">
                <template v-for="(authority,index) in tempModel"  v-bind:key="authority.FuncClassCode">
                    <div class="col-12 col-lg-6">
                        <p-card style="width: 25em" class="m-auto">
                            <template #title>
                                {{authority.FuncClassChName}}
                            </template>
                            <template #content>
                            <template v-for="(func,index) in authority.UserAuthorityFuncRsps" v-bind:key="func.UserAuthorityFuncRsps">
                                <div class="row mb-3">
                                    <label class="col-sm-8 col-form-label pt-0">{{func.FuncChName}}</label>
                                    <div class="col-sm-4">
                                        <div class="form-check">
                                            <input type="checkbox" class="p-checkbox p-component p-checkbox-checked form-check-input" style="margin-top:2px" v-bind:value="func.FuncCode" :checked="func.IsAuthority">
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
    </p-dialog>`
}