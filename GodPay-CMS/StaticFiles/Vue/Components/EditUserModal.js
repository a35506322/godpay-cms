export default {
    props: ['pemail'],
    data: function () {
        return {
            modal: {},
            email:''
        }
    },
    mounted: function () {
        this.modal = new bootstrap.Modal(this.$refs.modal);
    },
    methods: {
        Show: function () {
            this.modal.show();
        },
        Close: function () {
            this.modal.hide();
        },
        SaveProfile: function () {
            // 自定義,值
            this.$emit('save', this.email)
        }
    },
    watch: {
        pemail: function (newVal, oldVal) {
            console.log(newVal, oldVal)
            this.email = this.pemail
        }
    },
    template: `
    <v-form v-slot="{ values, errors}" v-on:submit="SaveProfile">
        <div class="modal fade" ref="modal" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog modal-lg">
            <div class="modal-content">
              <div class="modal-header bg-dark">
                <h4 class="modal-title text-light" id="staticBackdropLabel">編輯基本資料</h4>
                <button type="button" class="btn text-light p-0" data-bs-dismiss="modal" aria-label="Close">
                    <i class="bi bi-x-circle fs-3"></i>
                </button>
              </div>
              <div class="modal-body">
                <div class="container-fluid">
                    <div class="mb-3">
                        <label for="userEmail" class="form-label">Email</label>
                        <v-field type="email" class="form-control" name="email" id="userEamil" aria-describedby="emailHelp" v-model.trim="email" rules="email" v-bind:class="[{'is-invalid':errors['email']}]" autocomplete="off"></v-field>
                        <error-message name="email" class="invalid-feedback"></error-message>
                    </div>
                </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                <button type="button" class="btn btn-success" v-on:click="SaveProfile">儲存</button>
              </div>
            </div>
          </div>
        </div>
    </v-form>
    `
}