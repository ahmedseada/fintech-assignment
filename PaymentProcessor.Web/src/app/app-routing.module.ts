import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginComponent} from "./core/auth/login/login.component";
import {AddComponent} from "./core/payments/add/add.component";

const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: "add", component: AddComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
