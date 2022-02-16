import { GetListOfFunctionFilter } from '../Services/IpassService.js'

export default {
    data: function () {
        return {
            funcs: [],
        }
    },
    methods: {
        GetListOfFunctionFilter: async function (query) {
            try {
                const response = await GetListOfFunctionFilter(query).then(response => response);
                const status = response.status;
                if (status === 200) {
                    const rsponseData = response.data;
                    const code = rsponseData.rtnCode;
                    const deatil = rsponseData.rtnData;
                    const message = rsponseData.rtnMessage;
                    const status = this.$common.ChangeReturnCode(code);
                    switch (code) {
                        case 200:
                            if (deatil.length > 0) {
                                this.funcs = deatil[0].functions;
                            }
                            break;
                        case 403:
                            this.$toast.add({ severity: status, summary: message, detail: deatil, life: 5000, group: 'backend-laoout' });
                            break;
                        default:
                            throw new Error('代碼有誤');
                            break;
                    }
                }
            }
            catch (exception) {
                console.log(exception)
            }
        },
    }  
}