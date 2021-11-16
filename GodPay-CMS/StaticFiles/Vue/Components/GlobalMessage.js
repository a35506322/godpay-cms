export default {
    props: ['title', 'status', 'message'],
    data: function () {
        return {
            toast: {}
        }
    },
    mounted: function () {
        const option = {
            delay : 10000
        }
        this.toast = new bootstrap.Toast(this.$refs.globalMessage, option);
        this.show();
    },
    methods: {
        show: function () {
            this.toast.show();
        }
    },
    template:
        `
            <div class="toast" role="alert" aria-live="assertive" aria-atomic="true" ref="globalMessage">
                <div class="toast-header">
                    <span v-bind:class="'bg-'+status" class="p-2 rounded me-2 d-inline-block"></span>
                    <strong class="me-auto">{{title}}</strong>
                    <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
                </div>
                <div class="toast-body">
                    {{message}}
                </div>
            </div>
        `

}