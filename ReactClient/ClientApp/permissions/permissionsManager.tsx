import adminPermissions from './userPermissions/adminPermissions'
import employeePermissions from './userPermissions/employeePermissions'

class permissionsManager
{
    //This function is called from in the userManager.getUser() function in routes.tsx
    //This is to ensure the permissiosn are updated on each page change.
    public static getPermisisonsList(role:string) {
        switch (role) {
            case 'Administrator':
            return adminPermissions 
            case 'Employee':
            return employeePermissions           
            default:
            return [{actions: [], subject:''  }]
        }
    }
}
export default permissionsManager

