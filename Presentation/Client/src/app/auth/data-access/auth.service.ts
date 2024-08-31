import { Injectable } from '@angular/core';
import { HttpService } from "../../shared/data-access/http.service";
import { AngularFireAuth } from "@angular/fire/compat/auth";
import { GoogleAuthProvider } from "firebase/auth";
import { ToastrService } from "ngx-toastr";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpService, private afAuth: AngularFireAuth, private toastr: ToastrService) { }

  async login(email: string, password: string): Promise<void> {
    try {
      const userCredential = await this.afAuth.signInWithEmailAndPassword(email, password);

      if (userCredential.user) {
        const user = userCredential.user;
        const token = await user.getIdToken();
        localStorage.setItem('token', token);
      }
    } catch (error: any) {
      switch (error.code) {
        case 'auth/invalid-credential':
          this.toastr.error('Provided credentials are not valid', 'Error');
          break;
      }
    }
  }

  async register(name: string, email: string, password: string): Promise<void> {
    try {
      const userCredential = await this.afAuth.createUserWithEmailAndPassword(email, password);

      if (userCredential.user) {
        const user = userCredential.user;
        const token = await user.getIdToken();
        localStorage.setItem('token', token);
        await user.updateProfile({ displayName: name });
        await user.sendEmailVerification();
        await this.createUser(name, email, user.uid);
      }
    } catch (error: any) {
      switch (error.code) {
        case 'auth/email-already-in-use':
          this.toastr.error('Email is already in use', 'Error');
          break;
      }
    }
  }

  async loginWithGoogle() {
    try {
      const userCredential = await this.afAuth.signInWithPopup(new GoogleAuthProvider());

      if (userCredential.user) {
        const user = userCredential.user;
        const token = await user.getIdToken();
        localStorage.setItem('token', token);
        const registrationDate = new Date(user.metadata.creationTime!);

        // Check whether the user was registered just now (1 sec difference)
        if (registrationDate.getTime() - new Date().getTime() > -1000) {
          await this.createUser(user.displayName!, user.email!, user.uid);
        }

        // Google automatically verifies gmail.com domains and the business google domain only
        if (!user.emailVerified) {
          await user.sendEmailVerification();
        }
      }
    } catch (error) {
      this.toastr.error('Error', 'Something went wrong');
    }
  }

  private async createUser(name: string, email: string, firebaseUid: string) {
    await this.http.post('/users', { name: name, email: email, firebaseUid: firebaseUid}).toPromise();
  }
}
