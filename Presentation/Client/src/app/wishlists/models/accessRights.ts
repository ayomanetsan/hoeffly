import { DropdownOption } from '../../shared/models/dropdownOption';

export interface AccessRightsResponse {
  id: string;
  type: AccessType;
  name: string;
  email: string;
  initialType?: AccessType;
}

export interface ShareWishlistRequest {
  wishlistId: string;
  email: string;
  accessType: AccessType;
}

export enum AccessType {
  Owner = 0,
  Editor = 1,
  Viewer = 2
}

export const AccessTypeOptions: DropdownOption[] = [
  { text: 'Editor', value: AccessType.Editor },
  { text: 'Viewer', value: AccessType.Viewer }
];
