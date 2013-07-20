//
//  PaeDaeUnity.h
//
//
//  Created by Greg Morrison on 11/13/12.
//  Copyright (c) 2012 PaeDae Inc. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "PaeDaeSDK.h"

@interface PaeDaeUnity : NSObject

- (void) _PaeDaeWrapperInit:(const char *)key;
- (void) _PaeDaeWrapperShowAd:(const char *)zoneId;

@end
