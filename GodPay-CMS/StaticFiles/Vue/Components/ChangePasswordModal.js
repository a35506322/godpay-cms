import serverErrorMessage from '/StaticFiles/Vue/Components/ServerErrorMessage.js'
export default {
    props: ['modelError'],
    components: {
        serverErrorMessage
    },
    data: function () {
        return {
            displayModal: false,
            EditKeyViewModel: {}
        }
    },
    methods: {
        Show: function () {
            this.EditKeyViewModel = {}
            this.displayModal = true;
        },
        Close: function () {
            this.displayModal = false;
        },
        SaveKey: function () {
            this.$emit('save', this.EditKeyViewModel)
        }
    },
    template: `
    <p-dialog header="變更密碼" v-model:visible="displayModal" v-bind:style="{width:'50vw'}" v-bind:position="'top'" v-bind:modal="true">
        <v-form v-slot="{values, errors}" v-on:submit ="SaveKey">
            <div class="modal-body">
                <div class="container-fluid">                
                    <div class="mb-3">
                        <label for="oldkey" class="form-label">舊密碼</label>
                        <v-field type="password" class="p-inputtext p-component form-control" v-model.trim="EditKeyViewModel.OldKey" rules="required" name="密碼" id="oldkey" v-bind:class="[{'is-invalid':errors['密碼']||modelError['OldKey']}]" aria-describedby="emailHelp" autocomplete="off"></v-field>
                        <error-message name="密碼" class="invalid-feedback"></error-message>
                        <server-error-message v-bind:attr="'OldKey'"></server-error-message>
                    </div>
                    <div class="mb-3">
                        <label for="newkey" class="form-label">新密碼</label>
                        <v-field type="password" class="p-inputtext p-component form-control" v-model.trim="EditKeyViewModel.NewKey" rules="required" name="NewKey" id="newkey" v-bind:class="[{'is-invalid':errors['NewKey']||modelError['NewKey']}]" aria-describedby="emailHelp" autocomplete="off" ref="password"></v-field>
                        <error-message name="NewKey" class="invalid-feedback"></error-message>
                        <server-error-message v-bind:attr="'NewKey'"></server-error-message>
                    </div>
                    <div class="mb-3">
                        <label for="newkey2" class="form-label">再次輸入新密碼</label>
                        <v-field type="password" class="p-inputtext p-component form-control" v-model.trim="EditKeyViewModel.NewKey2" rules="required|confirmed:@NewKey" name="NewKey2" id="newkey2" v-bind:class="[{'is-invalid':errors['NewKey2']||modelError['NewKey2']}]" aria-describedby="emailHelp" autocomplete="off" data-vv-as="password"></v-field>
                        <error-message name="NewKey2" class="invalid-feedback"></error-message>
                        <server-error-message v-bind:attr="'NewKey2'"></server-error-message>
                    </div>
                </div>
            </div>
            <div class="p-dialog-footer">
                <p-button label="取消" icon="pi pi-times" v-on:click="Close()" class="p-button-text"></p-button>
                <p-button label="儲存" icon="pi pi-check" autofocus type="submit"></p-button>
            </div>
        </v-form>
    </p-dialog>
    `
}