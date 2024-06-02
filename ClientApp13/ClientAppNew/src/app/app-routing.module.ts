import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './shared/base/_guads/auth.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full'
  },    
  {
    path: 'login',
    component: LoginComponent   
  }, 
  { 
    path: 'dashboard',
    loadChildren: () => import('./components/dashboard/dashboard.module').then(m => m.DashboardModule),
    canActivate: [AuthGuard] 
  },
  { 
    path: 'country',
    loadChildren: () => import('./components/country/country.module').then(m => m.CountryModule),
    canActivate: [AuthGuard] 
  },
  {
    path: 'tournament',
    loadChildren: () => import('./components/tournament/tournament.module').then(m => m.TournamentModule),
    canActivate: [AuthGuard] 
  },  
  {
    path: 'role-group',
    loadChildren: () => import('./components/role-group/role-group.module').then(m => m.RoleGroupModule),
    canActivate: [AuthGuard] 
  },
  {
    path: 'roles',
    loadChildren: () => import('./components/roles/roles.module').then(m => m.RolesModule),
    canActivate: [AuthGuard] 
  },  
  {
    path: 'role-group',
    loadChildren: () => import('./components/role-group/role-group.module').then(m => m.RoleGroupModule),
    canActivate: [AuthGuard] 
  },  
  {
    path: 'user-group',
    loadChildren: () => import('./components/user-group/user-group.module').then(m => m.UserGroupModule),
    canActivate: [AuthGuard] 
  },
  {
    path: 'users',
    loadChildren: () => import('./components/users/users.module').then(m => m.UsersModule),
    canActivate: [AuthGuard] 
  },
  {
    path: 'haravan',
    loadChildren: () => import('./components/haravan/haravan.module').then(m => m.HaravanModule),
    canActivate: [AuthGuard] 
  },  
  {
    path: '**',
    redirectTo: 'login'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
