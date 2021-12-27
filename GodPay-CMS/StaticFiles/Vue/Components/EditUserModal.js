import serverErrorMessage from './ServerErrorMessage.js'
export default {
    props: ['pemail', 'modelError'],
    components: {
        serverErrorMessage
    },
    data: function () {
        return {
            displayModal: false,
            email:''
        }
    },
    methods: {
        Show: function () {
            this.email = this.pemail;            
            this.displayModal = true;
        },
        Close: function () {
            this.displayModal = false;
        },
        SaveProfile: function () {
            this.$emit('save', this.email)
        }
    },
    template: `

    <p-dialog header="編輯使用者" v-model:visible="displayModal" class="p-modal p-modal-lg" v-bind:position="'top'" v-bind:modal="true">
        <v-form v-slot="{values, errors}" v-on:submit ="SaveProfile">
             <div class="modal-body">
                <div class="container-fluid">                
                        <div class="mb-3">
                            <label for="userEmail" class="form-label">Email</label>
                            <v-field type="email" class="p-inputtext p-component form-control" name="email" id="userEamil"
                                    v-model.trim="email" rules="email|required" v-bind:class="[{'is-invalid':errors['email']||modelError['email']}]" autocomplete="off"></v-field>
                            <error-message name="email" class="invalid-feedback"></error-message>
                            <server-error-message v-bind:attr="'email'"></server-error-message>
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