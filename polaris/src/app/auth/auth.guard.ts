import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from './services';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private loginService: LoginService, private router: Router) { }

  canActivate( route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    // CERTO: const perfil = this.loginService.isGerente ? 'GERENTE' : 'CLIENTE';
    const perfil = this.loginService.isGerente ? 'CLIENTE' : 'GERENTE';
    let url = state.url;
    if (perfil) {
      if (route.data?.['role'] && route.data?.['role'].indexOf(perfil) === -1) {
        this.router.navigate(['auth/login'], { queryParams: { error: "Proibido o acesso a " + url } });
        return false;
      }
      return true;
    }
   
    this.router.navigate(['auth/login'], { queryParams: { error: "Deve fazer o login antes de acessar " + url } });
    return false;
  }
}
