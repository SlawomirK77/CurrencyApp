import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TableWrapperComponent } from './components/table-wrapper/table-wrapper.component';

const routes: Routes = [{ path: '', component: TableWrapperComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
