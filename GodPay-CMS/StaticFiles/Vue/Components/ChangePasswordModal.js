import serverErrorMessage from './ServerErrorMessage.js'
export default {
    props: ['modelError'],
    components: {
        serverErrorMessage
    },
    data: function () {
        return {
            displayModal: false,
            editKeyViewModel: {}
        }
    },
    methods: {
        Show: function () {
            this.editKeyViewModel = {}
            this.displayModal = true;
        },
        Close: function () {
            this.displayModal = false;
        },
        SaveKey: function () {
            this.$emit('save', this.editKeyViewModel)
        }
    },
    template: `
    <p-dialog header="變更密碼" v-model:visible="displayModal" class="p-modal p-modal-lg" v-bind:position="'top'" v-bind:modal="true">
        <v-form v-slot="{values, errors}" v-on:submit ="SaveKey">
            <div class="modal-body">
                <div class="container-fluid">                
                    <div class="mb-3">
                        <label for="oldkey" class="form-label">舊密碼</label>
                        <v-field type="password" class="p-inputtext p-component form-control" v-model.trim="editKeyViewModel.oldKey" rules="required" name="密碼" id="oldkey" v-bind:class="[{'is-invalid':errors['密碼']||modelError['oldKey']}]" aria-describedby="emailHelp" autocomplete="off"></v-field>
                        <error-message name="密碼" class="invalid-feedback"></error-message>
                        <server-error-message v-bind:attr="'oldKey'"></server-error-message>
                    </div>
                    <div class="mb-3">
                        <label for="newkey" class="form-label">新密碼</label>
                        <v-field type="password" class="p-inputtext p-component form-control" v-model.trim="editKeyViewModel.newKey" rules="required" name="新密碼" id="newkey" v-bind:class="[{'is-invalid':errors['新密碼']||modelError['newKey']}]" aria-describedby="emailHelp" autocomplete="off" ref="password"></v-field>
                        <error-message name="新密碼" class="invalid-feedback"></error-message>
                        <server-error-message v-bind:attr="'newKey'"></server-error-message>
                    </div>
                    <div class="mb-3">
                        <label for="newkey2" class="form-label">再次輸入新密碼</label>
                        <v-field type="password" class="p-inputtext p-component form-control" v-model.trim="editKeyViewModel.newKey2" rules="required|confirmed:@新密碼" name="再次輸入新密碼" id="newkey2" v-bind:class="[{'is-invalid':errors['再次輸入新密碼']||modelError['newKey2']}]" aria-describedby="emailHelp" autocomplete="off" data-vv-as="password"></v-field>
                        <error-message name="再次輸入新密碼" class="invalid-feedback"></error-message>
                        <server-error-message v-bind:attr="'newKey2'"></server-error-message>
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